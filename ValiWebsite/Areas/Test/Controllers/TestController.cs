using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ValiWebsite.Areas.Test.Controllers
{
	public class TestController : Controller
	{
		[Area("Test")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
