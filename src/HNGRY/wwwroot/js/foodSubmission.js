$(document).ready(function () {
    var
		/* SELECTORS */
		SUBMIT_FOOD_LOCATION_CSS = ".submit-food-location",
        SUBMIT_FOOD_MESSAGE_CSS = ".submit-food-message",
		SUBMIT_FOOD_BUTTON_CSS = ".submit-food",
		SUBMIT_FOOD_URL = "/Data/SubmitFood",

		/* CONSTANTS */
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
	    $(SUBMIT_FOOD_BUTTON_CSS).on(CLICK, function (event) {
	        _submitFood();
	    });
	},

	_submitFood = function () {
	    var locationToSubmit = $(SUBMIT_FOOD_LOCATION_CSS).val();
	    var messageToSubmit = $(SUBMIT_FOOD_MESSAGE_CSS).val();
	    $.ajax({
	        method: POST,
	        url: SUBMIT_FOOD_URL,
	        data: { location: locationToSubmit, message: messageToSubmit }
	    })
			.done(function () {
			    console.log("Your question was submitted.");
			    window.location.reload();
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