using Microsoft.EntityFrameworkCore;
using myfinance_aspnetcore_infra.Interfaces.Base;

namespace myfinance_aspnetcore_infra;

public abstract class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : EntityBase, new()
{

    protected DbContext DbContext;
    protected DbSet<TEntidade> DbSetContext;

    // Precisamos de um construtor para injetar a configuração para a construção do DbContext
    public Repository(DbContext dbContext)
    {
        this.DbContext = dbContext;
        this.DbSetContext = this.DbContext.Set<TEntidade>();
    }

    public void Cadastrar(TEntidade Entidade)
    {
        // Verificando se a entidade recebida é nova
        if (Entidade.Id == null)
        {
            // Adicionando a entidade ao contexto do banco de dados
            DbSetContext.Add(Entidade);
        }
        else
        {
            // Atualizando a entidade no contexto do banco de dados
            DbSetContext.Update(Entidade);
        }

        this.DbContext.SaveChanges();
    }

    public void Excluir(int id)
    {
        TEntidade entidadeParaExcluir = new TEntidade { Id = id };

        DbSetContext.Remove(entidadeParaExcluir);
        
        DbContext.SaveChanges();
    }

    public List<TEntidade> ListarRegistros()
    {
        return this.DbSetContext.ToList();
    }

    public TEntidade RetornarRegistro(int id)
    {
        return this.DbSetContext.Find(id);
    }

}