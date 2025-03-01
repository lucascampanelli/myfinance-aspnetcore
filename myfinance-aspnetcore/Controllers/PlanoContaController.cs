using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_aspnetcore.Models;



namespace myfinance_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class PlanoContaController : Controller
    {

        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
