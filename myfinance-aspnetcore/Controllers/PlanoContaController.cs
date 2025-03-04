using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_aspnetcore.Models;
using myfinance_aspnetcore_domain.Entities;
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

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            // Se o Id for nulo, então é um novo registro
            if (id == null)
                return View();


            var planoConta = _planoContaService.RetornarRegistro((int)id);

            var planoContaModel = new PlanoContaModel
            {
                Id = planoConta.Id,
                Descricao = planoConta.Descricao,
                Tipo = planoConta.Tipo
            };

            return View(planoContaModel);
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(PlanoContaModel model)
        {

            // Mapeando o PlanoContaModel para a entidade de PlanoConta
            PlanoConta planoConta = new PlanoConta
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            // Se o Id for igual a zero, então é um novo registro.
            // Caso contrário, atualiza o registro
            _planoContaService.Cadastrar(planoConta);

            // Redireciona para a rota "Index"
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _planoContaService.Excluir(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
