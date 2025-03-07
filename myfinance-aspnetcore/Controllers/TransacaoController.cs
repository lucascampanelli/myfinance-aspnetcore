using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_aspnetcore.Models;
using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_service.Interfaces;



namespace myfinance_aspnetcore.Controllers
{
    [Route("api/[controller]")]
    public class TransacaoController : Controller
    {

        private readonly ILogger<TransacaoController> _logger;
        private readonly IPlanoContaService _planoContaService;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(
                                    ILogger<TransacaoController> logger,
                                    IPlanoContaService planoContaService,
                                    ITransacaoService transacaoService
        )
        {
            _logger = logger;
            _planoContaService = planoContaService;
            _transacaoService = transacaoService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaTransacoes = _transacaoService.ListarRegistros();

            List<TransacaoModel> listaTransacoesModel = new List<TransacaoModel>();


            // Mapeamento da entidade de Transação para o model de Transação
            foreach (var item in listaTransacoes)
            {
                listaTransacoesModel.Add(new TransacaoModel
                {
                    Id = item.Id,
                    Historico = item.Historico,
                    Data = item.Data,
                    Valor = item.Valor,
                    Tipo = item.PlanoConta.Tipo,
                    PlanoContaId = item.PlanoContaId
                });
            }


            // Passando a lista de Transações para a View
            ViewBag.ListaTransacao = listaTransacoesModel;
            
            return View();
        }

        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(int? id)
        {
            // Cria uma lista para o dropdown, definind que o valor é o Id e a descrição é a Descrição
            var listaPlanoContas = new SelectList(_planoContaService.ListarRegistros(), "Id", "Descricao");

            var itemTransacao = new TransacaoModel
            {
                Data = DateTime.Now,
                ListaPlanoContas = listaPlanoContas
            };

            // Se o Id for nulo, então é um novo registro
            if (id == null)
                return View(itemTransacao);


            var transacao = _transacaoService.RetornarRegistro((int)id);


            itemTransacao.Id = transacao.Id;
            itemTransacao.Historico = transacao.Historico;
            itemTransacao.Data = transacao.Data;
            itemTransacao.Valor = transacao.Valor;
            itemTransacao.Tipo = transacao.PlanoConta.Tipo;
            itemTransacao.PlanoContaId = transacao.PlanoContaId;


            return View(itemTransacao);
        }

        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{id}")]
        public IActionResult Cadastrar(TransacaoModel model)
        {

            // Mapeando o TransacaoModel para a entidade de transacao
            Transacao transacao = new Transacao
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };

            // Se o Id for igual a zero, então é um novo registro.
            // Caso contrário, atualiza o registro
            _transacaoService.Cadastrar(transacao);

            // Redireciona para a rota "Index"
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _transacaoService.Excluir(id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
