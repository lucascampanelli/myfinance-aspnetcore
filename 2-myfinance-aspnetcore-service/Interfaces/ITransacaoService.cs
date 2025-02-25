using myfinance_aspnetcore_domain.Entities;

namespace myfinance_aspnetcore_service.Interfaces;

public interface ITransacaoService
{

    void Cadastrar(Transacao entidade);

    void Excluir(int id);

    List<Transacao> ListarRegistros();

    Transacao RetornarRegistro(int id);

}
