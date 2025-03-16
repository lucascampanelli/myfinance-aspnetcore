using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_infra.Interfaces.Base;

namespace myfinance_aspnetcore_infra.Interfaces;


// Interface que define um repositório para a entidade PlanoConta
public interface IPlanoContaRepository : IRepository<PlanoConta>
{ }