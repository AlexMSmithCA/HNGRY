$(document).ready(function() {
    var
        UNDELETE_BUTTON_CSS = ".post-undelete-button",
        CONFIRM_BUTTON_CSS = ".post-confirm-button",
        UNAVAILABLE_BUTTON_CSS = ".post-unavailable-button",
        DATA_FEED_ID_CSS = "data-feed-id",
        FEED_POST_CSS = ".feed-post",
        UPDATE_URL = "Data/UpdateFeedEntry",

        /* CONSTANTS */
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
	    $(UNDELETE_BUTTON_CSS).on(CLICK, function (event) {
	        _undelete($(event.currentTarget).attr(DATA_FEED_ID_CSS));
	    });
	    $(CONFIRM_BUTTON_CSS).on(CLICK, function (event) {
	        _confirm($(event.currentTarget).attr(DATA_FEED_ID_CSS));
	    });
	    $(UNAVAILABLE_BUTTON_CSS).on(CLICK, function (event) {
	        _unavailable($(event.currentTarget).attr(DATA_FEED_ID_CSS));
	    });
	},

    _undelete = function (id) {
        $.ajax({
            method: POST,
            url: UPDATE_URL,
            data: {id:id, changeType:0}
        })
			.done(function () {
			    console.log("Success");
			    window.location.reload();
			})
			.fail(function () {
			    console.log("Failure");
			});
    },
    _confirm = function (id) {
        $.ajax({
            method: POST,
            url: UPDATE_URL,
            data: { id: id, changeType: 1 }
        })
			.done(function () {
			    console.log("Success");
			    window.location.reload();
			})
			.fail(function () {
			    console.log("Failure");
			});
    },
    _unavailable = function (id) {
        $.ajax({
            method: POST,
            url: UPDATE_URL,
            data: { id: id, changeType: 2 }
        })
			.done(function () {
			    console.log("Success");
			    window.location.reload();
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