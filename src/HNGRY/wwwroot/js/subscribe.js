$(document).ready(function () {
    var
		/* SELECTORS */
        SUBSCRIBE_EMAIL_CSS = "#inputEmail3",
        SUBSCRIBE_PHONE_CSS = "#inputPhoneNumber3",
        SUBSCRIBE_EMAIL_DIV_CSS = ".email-input",
        SUBSCRIBE_PHONE_DIV_CSS = ".phone-input",
		SUBSCRIBE_BUTTON_CSS = ".subscribe-button",
        FOOD_CHECKBOX_CSS = "#foodSubmissionCheckbox",
        POSTS_CHECKBOX_CSS = "#postsFromCheckbox",
        EMAIL_CHECKBOX_CSS = "#emailCheckbox",
        PHONE_CHECKBOX_CSS = "#phoneCheckbox",
        SUBSCRIBE_SUCCESS_CSS = ".success-message",
        SUBSCRIBE_URL = "/Data/Subscribe",


		/* CONSTANTS */
		CLICK = "click",
		POST = "POST",
        CHECKED = ":checked",

	initialize = function () {
	    
	},

	renderUI = function () {
	    // Put any initial rendering stuff here
	},

	bindUI = function () {
	    
	    $(EMAIL_CHECKBOX_CSS).on(CLICK, function (event) {
	        if ($(EMAIL_CHECKBOX_CSS).is(CHECKED)) {
	            $(SUBSCRIBE_EMAIL_DIV_CSS).show();
	        } else {
	            $(SUBSCRIBE_EMAIL_DIV_CSS).hide();
	        }
	    });
	    $(PHONE_CHECKBOX_CSS).on(CLICK, function (event) {
	        if ($(PHONE_CHECKBOX_CSS).is(CHECKED)) {
	            $(SUBSCRIBE_PHONE_DIV_CSS).show();
	        } else {
	            $(SUBSCRIBE_PHONE_DIV_CSS).hide();
	        }
	    });


	    // Put any bindings here
	    $(SUBSCRIBE_BUTTON_CSS).on(CLICK, function (event) {
	        _subscribe();
	    });
	},

	_subscribe = function () {
	    var emailToSubmit = $(SUBSCRIBE_EMAIL_CSS).val();
	    var phoneToSubmit = $(SUBSCRIBE_PHONE_CSS).val();
	    var foodCheckboxToSubmit = + $(FOOD_CHECKBOX_CSS).is(CHECKED);
	    var postsCheckboxToSubmit = + $(POSTS_CHECKBOX_CSS).is(CHECKED);
	    var emailCheckboxToSubmit = + $(EMAIL_CHECKBOX_CSS).is(CHECKED);
	    var phoneCheckboxToSubmit = + $(PHONE_CHECKBOX_CSS).is(CHECKED);

	    $.ajax({
	        method: POST,
	        url: SUBSCRIBE_URL,
	        data: {phone:phoneToSubmit, foodSubmissions:foodCheckboxToSubmit, email:emailToSubmit, 
	            postsFrom: postsCheckboxToSubmit, emailAlert: emailCheckboxToSubmit, textAlert: phoneCheckboxToSubmit
	        }
	    })
			.done(function () {
			    console.log("Subscription updated!");
			    $(SUBSCRIBE_SUCCESS_CSS).show();
			})
			.fail(function () {
			    console.log("Oh no, you won't get food updates");
			});
	},
	_done;

    initialize();
    renderUI();
    bindUI();
});