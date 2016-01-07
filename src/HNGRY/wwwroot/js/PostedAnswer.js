$(document).ready(function() {
	var SUBMIT_QUESTION_TEXT_CSS = ".submit-question-text",
		SUBMIT_QUESTION_BUTTON_CSS = ".submit-question-button",
		SUBMIT_QUESTION_URL = "/Home/SubmitQuestion",
		CLICK = "click",

	initialize = function() {
		// Put the initialization stuff here
	},

	renderUI = function() {
		// Put any initial rendering stuff here
	},

	bindUI = function() {
		// Put any bindings here
		$(SUBMIT_QUESTION_BUTTON_CSS).on(CLICK, function(event) {
			var questionToSubmit = $(SUBMIT_QUESTION_TEXT_CSS).text();
			$.ajax({
					method: "POST",
					url: SUBMIT_QUESTION_URL,
					data: { text: questionToSubmit }
				})
				.done(function() {
					console.log("Your question was submitted.");
				})
				.fail(function() {
					console.log("Yikes!  Something went wrong :(.  Please contact Sean Walsh for assistance.");
				});
		});
	},

	_submitQuestion = function() {
		
	}

	initialize();
	renderUI();
	bindUI();

});