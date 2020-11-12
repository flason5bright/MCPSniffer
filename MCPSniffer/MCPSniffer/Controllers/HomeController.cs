using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MCPSniffer.Models;
using MCPSniffer.Interface;
using ElasticSeachSDK;

namespace MCPSniffer.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISniffer _sniffer;

		public HomeController(ILogger<HomeController> logger, ISniffer sniffer)
		{
			_logger = logger;
			_sniffer = sniffer;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}


		public ActionResult Result(string condition)
		{
			if (string.IsNullOrEmpty(condition))
			{
				return RedirectToAction("/");
			}

			var result = _sniffer.GetMCPFileInfosByCondition(condition);
			ViewData["Result"] = result;
			ViewData["condition"] = condition;
			return View();
		}


		public ActionResult Detail(int id,string condition)
		{
			var result = _sniffer.GetResultByIdAndCondition(condition, id);
			ViewData["Result"] = result;
			ViewData["condition"] = condition;
			return View();
		}
	}
}
