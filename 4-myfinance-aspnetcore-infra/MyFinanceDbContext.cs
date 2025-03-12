using Microsoft.EntityFrameworkCore;
using myfinance_aspnetcore_domain.Entities;



namespace myfinance_aspnetcore_infra;

public class MyFinanceDbContext : DbContext
{

    // Injeção de dependência para a interface de configuração
    private readonly IConfiguration _configuration;

    // Atributo para mapear a tabela PlanoConta
    public DbSet<PlanoConta> PlanoConta { get; set; }
    // Atributo para mapear a tabela Transacao
    public DbSet<Transacao> Transacao { get; set; }

    private string _caminhoDB;

    public MyFinanceDbContext(IConfiguration configuration)
    {
        this._configuration = configuration;

        var pasta = Environment.SpecialFolder.LocalApplicationData;
        var caminho = Environment.GetFolderPath(pasta);
        
        this._caminhoDB = System.IO.Path.Join(caminho, "myfinance.db");
    }

    // Método sobrescrito para configurar o banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Caso uma connection string fosse utilizada, seria algo como:
        // optionsBuilder.UseSqlServer(this._configuration.GetConnectionString("Database"));

        optionsBuilder.UseSqlite($"Data Source={this._caminhoDB}");
    }

}