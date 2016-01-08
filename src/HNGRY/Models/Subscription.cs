namespace HNGRY.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Subscription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AccountID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int FoodSubmissions { get; set; }

        public int PostsFrom { get; set; }

        public int EmailAlert { get; set; }

        public int TextAlert { get; set; }
    }
}
