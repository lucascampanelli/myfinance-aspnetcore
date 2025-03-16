namespace myfinance_aspnetcore_infra.Interfaces.Base;

// Interface que define um repositório genérico
public interface IRepository<TEntidade> where TEntidade : class
{
    
    /// <summary>
    ///     Método para cadastrar um novo registro
    /// </summary>
    public void Cadastrar(TEntidade Entidade);


    /// <summary>
    ///     Método responsavel por excluir um plano de conta
    /// </summary>
    public void Excluir(int id);


    /// <summary>
    ///    Método responsável por listar todas as entidades
    /// </summary>
    /// <returns></returns>
    public List<TEntidade> ListarRegistros();


    /// <summary>
    ///    Método responsável por retornar uma entidade pelo id
    /// </summary>
    /// <param name="id"></param>
    public TEntidade RetornarRegistro(int id);

}