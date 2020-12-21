using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPgCmd _pgCmd;

        public HomeController(ILogger<HomeController> logger, IPgCmd p)
        {
            _logger = logger;
            _pgCmd = p;
        }

        public async Task<IActionResult> Index()
        {
            var cmd = await _pgCmd.GetCmd("SELECT 'satu'");
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));
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
