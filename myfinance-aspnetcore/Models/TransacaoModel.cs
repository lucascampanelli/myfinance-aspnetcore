using myfinance_aspnetcore_domain.Entities;

namespace myfinance_aspnetcore.Models;

public class TransacaoModel
{
    public int? Id { get; set; }
    public string Historico { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public string Tipo { get; set; }
    public int PlanoContaId { get; set; }
    public PlanoConta PlanoConta { get; set; }
}
