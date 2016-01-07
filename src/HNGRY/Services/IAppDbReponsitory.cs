﻿namespace HNGRY.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using HNGRY.Models;

	public interface IAppDbRepository
    {
	    List<QuestionSubmission> GetQuestionSubmissions();
	    Task AddQuestionSubmission(string question);
    }
}
