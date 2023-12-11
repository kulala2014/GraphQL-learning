using GraphQLDemo.Data;
using GraphQLDemo.Models;
using GraphQLDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GraphQLDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlayersService _playersService;

        public HomeController(ILogger<HomeController> logger, IPlayersService playersService)
        {
            _logger = logger;
            _playersService = playersService;
        }

        public IActionResult Index()
        {

           var result = _playersService.GetPlayersAsync().Result;

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
