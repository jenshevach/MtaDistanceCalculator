using System.Web.Mvc;

namespace MtaDistanceCalculator.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "MTA Station Distance Calculator";

			return View();
		}
	}
}
