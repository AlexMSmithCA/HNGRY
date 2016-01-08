$(document).ready(function() {
	var
		/* SELECTORS */
		SUBMIT_QUESTION_TEXT_CSS = "#question-message",
		SUBMIT_QUESTION_BUTTON_CSS = ".submit-question-button",
		SUBMIT_QUESTION_URL = "/Data/SubmitQuestion",
        SUBSCRIBE_SUCCESS_CSS = ".success-message",

		CLICK = "click",
		POST = "POST",

	initialize = function () {
	    // Put the initialization stuff here
	},

	renderUI = function () {
	    // Put any initial rendering stuff here
	},

	bindUI = function () {
	    // Put any bindings here
	    $(SUBMIT_QUESTION_BUTTON_CSS).on(CLICK, function (event) {
	        if ($(SUBMIT_QUESTION_TEXT_CSS).val() != "") {
	            _submitQuestion();
	        }
	    });
	},

	_submitQuestion = function () {
	    var questionToSubmit = $(SUBMIT_QUESTION_TEXT_CSS).val();
	    $.ajax({
	        method: POST,
	        url: SUBMIT_QUESTION_URL,
	        data: { question: questionToSubmit }
	    })
			.done(function () {
			    console.log("Your question was submitted.");
			    $(SUBSCRIBE_SUCCESS_CSS).show();
			    $(SUBMIT_QUESTION_TEXT_CSS).val("");
			})
			.fail(function () {
			    console.log("Yikes!  Something went wrong :(.  Take the food and run.");
			});
	},
	_done;

    initialize();
    renderUI();
    bindUI();

});