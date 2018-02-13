(function () {
	var username = prompt('Please enter a username:');
	$("#username").text(username);
	var connection = new WebSocket(`ws://localhost:2212/api/websocket?username=${username}`);

	connection.onopen = function (event) {
		$(".chat-history").append(`<div>${username} joined the chat</div>`);
		$("#chatform").submit(function (event) {
			connection.send($("#inputbox").val());
			$("#inputbox").val("");
			event.preventDefault();
		});
	};

	connection.onmessage = function (event) {
		var message = JSON.parse(event.data);
		$(".chat-history").append(
			`<div class="chat-message clearfix">
			<img src="${message.Avatar}" alt="avatar" width="32" height="32">
				<div class="chat-message-content clearfix">
					<span class="chat-time">${message.TimeStamp}</span>
					<h5>${message.Username}</h5><p>${message.Message}</p>
				</div>
			</div>
			<hr>`);

		$(".chat-history").animate({ scrollTop: $('.chat-history').prop("scrollHeight") }, 1000);
	}

	connection.onerror = function (event) {
		$(".chat-history").prepend('<div>something went wrong!</div>');
	};

	$('#live-chat header').on('click', function () {
		$('.chat').slideToggle(300, 'swing');
		$('.chat-message-counter').fadeToggle(300, 'swing');
	});

	$('.chat-close').on('click', function (e) {
		e.preventDefault();
		$('#live-chat').fadeOut(300);
	});
})();
