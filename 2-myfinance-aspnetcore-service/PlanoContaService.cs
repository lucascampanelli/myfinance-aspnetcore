using myfinance_aspnetcore_service.Interfaces;
using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_infra.Interfaces;



namespace myfinance_aspnetcore_service;

public class PlanoContaService : IPlanoContaService
{

    // Injeção de dependência do repositório
    private readonly IPlanoContaRepository _planoContaRepository;

    public PlanoContaService(IPlanoContaRepository planoContaRepository)
    {
        _planoContaRepository = planoContaRepository;
    }


    public void Cadastrar(PlanoConta planoConta)
    {
        _planoContaRepository.Cadastrar(planoConta);
    }

    public void Excluir(int id)
    {
        _planoContaRepository.Excluir(id);
    }

    public List<PlanoConta> ListarRegistros()
    {
        return _planoContaRepository.ListarRegistros();
    }

    public PlanoConta RetornarRegistro(int id)
    {
        return _planoContaRepository.RetornarRegistro(id);
    }
}
