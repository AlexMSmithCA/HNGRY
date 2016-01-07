namespace HNGRY.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
