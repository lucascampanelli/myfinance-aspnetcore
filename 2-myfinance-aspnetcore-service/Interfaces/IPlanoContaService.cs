using myfinance_aspnetcore_domain.Entities;

namespace myfinance_aspnetcore_service.Interfaces;

public interface IPlanoContaService
{

    void Cadastrar(PlanoConta entidade);

    void Excluir(int id);

    List<PlanoConta> ListarRegistros();

    PlanoConta RetornarRegistro(int id);

}
