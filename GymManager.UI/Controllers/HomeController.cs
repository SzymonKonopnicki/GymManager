using GymManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GymManager.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //_logger.LogInformation("LogInfo");
            //_logger.LogError(new Exception("LogError"), null);

            //var ticket = await Mediator.Send(new GetTicketByIdQuery { Id = 1 });
            //await Mediator.Send(new AddTicketCommand { Name = "Default name" });

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
    }
}
