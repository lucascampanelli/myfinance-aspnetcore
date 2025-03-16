using myfinance_aspnetcore_domain.Entities;
using myfinance_aspnetcore_infra.Interfaces;

namespace myfinance_aspnetcore_infra.Repositories;

public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
{
    public PlanoContaRepository(MyFinanceDbContext myFinanceDbContext) : base(myFinanceDbContext)
    {
    }
}