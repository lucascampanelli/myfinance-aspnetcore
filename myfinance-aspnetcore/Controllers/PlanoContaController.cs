using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_aspnetcore.Models;
using myfinance_aspnetcore_service.Interfaces;



namespace myfinance_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class PlanoContaController : Controller
    {

        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(
                                    ILogger<PlanoContaController> logger,
                                    IPlanoContaService planoContaService
        )
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();

            List<PlanoContaModel> listaPlanoContasModel = new List<PlanoContaModel>();


            // Mapeamento da entidade de Plano Conta para o model de Plano Conta
            foreach (var item in listaPlanoContas)
            {
                listaPlanoContasModel.Add(new PlanoContaModel
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                });
            }


            // Passando a lista de Plano Contas para a View
            ViewBag.ListaPlanoContas = listaPlanoContasModel;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
