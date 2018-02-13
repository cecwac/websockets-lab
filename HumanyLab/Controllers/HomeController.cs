using System.Web.Mvc;

namespace HumanyLab.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}