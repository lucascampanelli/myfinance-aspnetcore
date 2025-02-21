using Microsoft.EntityFrameworkCore;
using myfinance_aspnetcore_domain.Entities;



namespace myfinance_aspnetcore_infra;

public class MyFinanceDbContext : DbContext
{

    // Atributo para mapear a tabela PlanoConta
    public DbSet<PlanoConta> PlanoConta { get; set; }
    // Atributo para mapear a tabela Transacao
    public DbSet<Transacao> Transacao { get; set; }


    // Método sobrescrito para configurar o banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=myfinance.db");
    }

}
