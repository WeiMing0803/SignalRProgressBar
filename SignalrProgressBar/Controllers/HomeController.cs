using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalrProgressBar.Hubs;
using SignalrProgressBar.Models;
using System.Diagnostics;

namespace SignalrProgressBar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger,
            IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            this._hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StartProgress()
        {
            for (int i = 0; i <= 100; i += 1)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveProgress", i);
                await Task.Delay(1000);
            }
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}