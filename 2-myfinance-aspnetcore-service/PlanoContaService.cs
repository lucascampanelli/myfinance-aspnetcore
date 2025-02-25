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

    /// <summary>
    ///     Método para cadastrar um plano de conta
    /// </summary>
    /// <param name="entidade"></param>
    public void Cadastrar(PlanoConta entidade)
    {
        // Obtendo o mapeamento da entidade PlanoConta
        var dbSet = this.contextoBD.PlanoConta;

        // Verificando se a entidade recebida é nova
        if (entidade.Id == null)
        {
            // Adicionando a entidade ao contexto do banco de dados
            dbSet.Add(entidade);
        }
        else
        {
            // Atualizando a entidade no contexto do banco de dados
            dbSet.Update(entidade);
        }

        this.contextoBD.SaveChanges();
    }


    /// <summary>
    ///     Método responsavel por excluir um plano de conta
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception> 
    public void Excluir(int id)
    {
        PlanoConta planoContaParaExcluir = new PlanoConta { Id = id };

        this.contextoBD.PlanoConta.Remove(planoContaParaExcluir);
        
        this.contextoBD.SaveChanges();
    }


    /// <summary>
    ///    Método responsável por listar todos os planos de conta
    /// </summary>
    /// <returns></returns>
    public List<PlanoConta> ListarRegistros()
    {
        return this.contextoBD.PlanoConta.ToList();
    }


    /// <summary>
    ///    Método responsável por retornar um plano de conta pelo id
    /// </summary>
    /// <param name="id"></param>
    public PlanoConta RetornarRegistro(int id)
    {
        return this.contextoBD.PlanoConta.Where(x => x.Id == id).First();
    }
}
