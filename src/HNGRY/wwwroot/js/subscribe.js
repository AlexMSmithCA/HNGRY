$(document).ready(function () {
    var
		/* SELECTORS */
		SUBSCRIBE_NAME_CSS = ".nameInput",
        SUBSCRIBE_EMAIL_CSS = ".emailInput",
        SUBSCRIBE_PHONE_CSS = ".phoneNumberInput",
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
		HIDDEN = "hidden",

	initialize = function () {
	    
	},

	renderUI = function () {
	    // Put any initial rendering stuff here
	},

	bindUI = function () {
	    
	    $(EMAIL_CHECKBOX_CSS).on(CLICK, function (event) {
	        if ($(EMAIL_CHECKBOX_CSS).is(CHECKED)) {
	            $(SUBSCRIBE_EMAIL_DIV_CSS).removeClass(HIDDEN);
	        } else {
	            $(SUBSCRIBE_EMAIL_DIV_CSS).addClass(HIDDEN);
	        }
	    });
	    $(PHONE_CHECKBOX_CSS).on(CLICK, function (event) {
	        if ($(PHONE_CHECKBOX_CSS).is(CHECKED)) {
	        	$(SUBSCRIBE_PHONE_DIV_CSS).removeClass(HIDDEN);
	        } else {
	        	$(SUBSCRIBE_PHONE_DIV_CSS).addClass(HIDDEN);
	        }
	    });


	    // Put any bindings here
	    $(SUBSCRIBE_BUTTON_CSS).on(CLICK, function (event) {
	        _subscribe();
	    });
	},

	_subscribe = function () {
		var nameToSubmit = $(SUBSCRIBE_NAME_CSS).val();
	    var emailToSubmit = $(SUBSCRIBE_EMAIL_CSS).val();
	    var phoneToSubmit = $(SUBSCRIBE_PHONE_CSS).val();
	    var foodCheckboxToSubmit = $(FOOD_CHECKBOX_CSS).is(CHECKED);
	    var postsCheckboxToSubmit = $(POSTS_CHECKBOX_CSS).is(CHECKED);
	    var emailCheckboxToSubmit = $(EMAIL_CHECKBOX_CSS).is(CHECKED);
	    var phoneCheckboxToSubmit = $(PHONE_CHECKBOX_CSS).is(CHECKED);

	    if (!emailCheckboxToSubmit) emailToSubmit = null;
		if (!phoneCheckboxToSubmit) phoneToSubmit = null;

	    $.ajax({
	        method: POST,
	        url: SUBSCRIBE_URL,
				data: {
	        		name: nameToSubmit,
	        		phone: phoneToSubmit,
	        		foodSubmissions: foodCheckboxToSubmit,
	        		email: emailToSubmit,
	        		postsFrom: postsCheckboxToSubmit,
	        		emailAlert: emailCheckboxToSubmit,
	        		textAlert: phoneCheckboxToSubmit
				}
			})
			.done(function () {
			    console.log("Subscription updated!");
			    $(SUBSCRIBE_SUCCESS_CSS).show();
			    $(SUBSCRIBE_NAME_CSS).val("");
			    $(SUBSCRIBE_EMAIL_CSS).val("");
			    $(SUBSCRIBE_PHONE_CSS).val("");
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