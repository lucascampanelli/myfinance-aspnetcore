using myfinance_aspnetcore_service.Interfaces;
using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_infra;
using Microsoft.EntityFrameworkCore;



namespace myfinance_aspnetcore_service;

public class TransacaoService : ITransacaoService
{

    // Contexto do banco de dados do Entity Framework
    private readonly MyFinanceDbContext contextoBD;

    // Construtor com a injenção de dependência do contexto do banco de dados
    public TransacaoService(MyFinanceDbContext contextoBD)
    {
        this.contextoBD = contextoBD;
    }


    /// <summary>
    ///     Método para cadastrar uma transação
    /// </summary>
    /// <param name="entidade"></param>
    public void Cadastrar(Transacao entidade)
    {
        // Obtendo o mapeamento da entidade Transacao
        var dbSet = this.contextoBD.Transacao;

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
    ///     Método responsavel por excluir uma transação pelo id
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception> 
    public void Excluir(int id)
    {
        Transacao transacaoParaExcluir = new Transacao { Id = id };

        this.contextoBD.Transacao.Remove(transacaoParaExcluir);
        
        this.contextoBD.SaveChanges();
    }


    /// <summary>
    ///    Método responsável por listar todas as transações
    /// </summary>
    /// <returns></returns>
    public List<Transacao> ListarRegistros()
    {
        return this.contextoBD.Transacao.Include(x => x.PlanoConta).ToList();
    }


    /// <summary>
    ///    Método responsável por retornar uma transação pelo id
    /// </summary>
    /// <param name="id"></param>
    public Transacao RetornarRegistro(int id)
    {
        return this.contextoBD.Transacao.Include(x => x.PlanoConta).Where(x => x.Id == id).First();
    }
}
