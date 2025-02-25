using myfinance_aspnetcore_service.Interfaces;
using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_infra;



namespace myfinance_aspnetcore_service;

public class PlanoContaService : IPlanoContaService
{

    // Contexto do banco de dados do Entity Framework
    private readonly MyFinanceDbContext contextoBD;

    // Construtor com a injenção de dependência do contexto do banco de dados
    public PlanoContaService(MyFinanceDbContext contextoBD)
    {
        this.contextoBD = contextoBD;
    }

    public void Cadastrar(PlanoConta entidade)
    {
        throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        throw new NotImplementedException();
    }

    public List<PlanoConta> ListarRegistros()
    {
        throw new NotImplementedException();
    }

    public PlanoConta RetornarRegistro(int id)
    {
        throw new NotImplementedException();
    }
}
