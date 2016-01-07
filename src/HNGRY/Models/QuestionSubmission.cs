namespace HNGRY.Models
{
	using System;
    using System.ComponentModel.DataAnnotations;

    public class QuestionSubmission
    {
        [Key]
        public int Id { get; set; }

        public string QuestionText { get; set; }
    }
}
