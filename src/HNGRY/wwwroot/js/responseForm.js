$(document).ready(function() {
    var 
        RESPONSE_TITLE_CSS = "#response-title",
        RESPONSE_MESSAGE_CSS = "#response-message",
        RESPONSE_AUTHOR_CSS = "#response-author",
        RESPONSE_BUTTON_CSS = ".submit-response",
        RESPONSE_SUCCESS_CSS = ".submit-response-success",
        RESPONSE_SUBMIT_URL = "/Data/SubmitResponse",

        CLICK = "click",
		POST = "POST",
	initialize = function() {
		// Put the initialization stuff here
	},

	renderUI = function() {
		// Put any initial rendering stuff here
	},

	bindUI = function() {
	    // Put any bindings here
	    $(RESPONSE_BUTTON_CSS).on(CLICK, function (event) {
	        _submit();
	    });
	},

     _submit = function () {
         var title = $(RESPONSE_TITLE_CSS).val();
         var author = $(RESPONSE_AUTHOR_CSS).val();
         var message = $(RESPONSE_MESSAGE_CSS).val();

         $.ajax({
             method: POST,
             url: RESPONSE_SUBMIT_URL,
             data: { title:title, author:author, message:message }
         })
             .done(function () {
                 console.log("Success");
                 $(RESPONSE_SUCCESS_CSS).show();
             })
             .fail(function () {
                 console.log("Failure");
             });
     },

	_done;

	initialize();
	renderUI();
	bindUI();
});