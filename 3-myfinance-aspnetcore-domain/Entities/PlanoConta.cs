using myfinance_aspnetcore_infra;

namespace myfinance_aspnetcore_domain.Entities;


public class PlanoConta : EntityBase
{
    public string Descricao { get; set; }
    public string Tipo { get; set; }
}