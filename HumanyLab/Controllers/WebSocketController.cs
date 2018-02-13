using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Web.WebSockets;
using HumanyLab.Handlers;

namespace HumanyLab.Controllers
{
	public class WebSocketController : ApiController
	{
		public HttpResponseMessage Get(string username)
		{
			if (HttpContext.Current.IsWebSocketRequest || HttpContext.Current.IsWebSocketRequestUpgrading)
			{
				HttpContext.Current.AcceptWebSocketRequest(new ChatWebSocketHandler(username));
				return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
			}
			else
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
		}
	}
}
