using Microsoft.Web.WebSockets;
using Newtonsoft.Json;
using System;

namespace HumanyLab.Handlers
{
	public class ChatWebSocketHandler : WebSocketHandler
	{
		private static readonly WebSocketCollection _chatClients = new WebSocketCollection();
		private string _userName;
		private string _avatar;

		public ChatWebSocketHandler(string userName)
		{
			_userName = userName;
			_avatar = "https://picsum.photos/32/32/?random";
		}

		public override void OnOpen()
		{
			_chatClients.Add(this);
		}

		public override void OnMessage(string message)
		{
			var newMessage = new { Username = _userName, Message = message, Avatar = _avatar, TimeStamp = DateTime.Now.ToString("HH:mm") };
			_chatClients.Broadcast(JsonConvert.SerializeObject(newMessage));
		}

		public override void OnClose()
		{
			base.OnClose();
		}

		public override void OnError()
		{
			base.OnError();
		}
	}
}