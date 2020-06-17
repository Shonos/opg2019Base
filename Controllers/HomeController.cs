using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using opg_201910_interview.BusinessLogic;
using opg_201910_interview.Models;

namespace opg_201910_interview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<ClientSettingsModel> _clientSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<ClientSettingsModel> clientSettings)
        {
            _logger = logger;
            _clientSettings = clientSettings;
        }

        public IActionResult Index()
        {

            var model = new HomeViewModel()
            {
                FilesForEnumeration = ClientFactory.GetClientBusinessLogic(_clientSettings).EnumerateFiles()
            };
            return View(model);
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
    }
}
