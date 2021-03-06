﻿namespace HNGRY
{
	using System;
	using Autofac;
	using Microsoft.AspNet.Builder;
	using Autofac.Extensions.DependencyInjection;
	using Microsoft.AspNet.Hosting;
	using Microsoft.Data.Entity;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Logging;
	using HNGRY.Models;
	using HNGRY.Services;
	using Microsoft.Extensions.PlatformAbstractions;
	using Newtonsoft.Json.Serialization;
	using HNGRY.SampleSeeder;
	using Microsoft.AspNet.Identity.EntityFramework;

	public class Startup
    {
	    internal static IContainer ServiceLocator;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Set up configuration sources.
	        var builder = new ConfigurationBuilder()
				.SetBasePath(appEnv.ApplicationBasePath)
		        .AddJsonFile("appsettings.json")
		        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			// Add framework services.
			services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

			services.AddIdentity<User, IdentityRole>(a =>
					{
						a.Password.RequireDigit = false;
						a.Password.RequireLowercase = false;
						a.Password.RequireNonLetterOrDigit = false;
						a.Password.RequireUppercase = false;
						a.Password.RequiredLength = 0;
						a.User.AllowedUserNameCharacters = a.User.AllowedUserNameCharacters + "\\";
						a.User.RequireUniqueEmail = false;
						a.SignIn.RequireConfirmedEmail = false;
						a.SignIn.RequireConfirmedPhoneNumber = false;

					})
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			services.AddMvc()
		        .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISmsSender, SmsSender>();
	        services.AddScoped<IAppDbRepository, AppDbRepository>();

			// Data seeding services
			services.AddTransient<SeedUsers>();
			services.AddTransient<SeedPostedAnswers>();
            services.AddTransient<SeedFeedEntries>();
			services.AddTransient<SampleDataSeeder>();

			var builder = new ContainerBuilder();
			builder.Populate(services);

	        Startup.ServiceLocator = builder.Build();
	        return ServiceLocator.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SampleDataSeeder sampleDataSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<AppDbContext>()
                             .Database
							 .EnsureCreated();
                    }
                }
                catch { }
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

			app.UseIdentity();

			// To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

			app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
					defaults: new { controller = "Navigation", action = "Index" });
            });

	        await sampleDataSeeder.InitializeSeedData();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
