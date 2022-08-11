using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface ICategoriaBebidaRepositorio : IGeralRepositorio
    {
        Task<CategoriaBebida[]> GetAllAsync();
        Task<CategoriaBebida> GetByIdAsync(int id);
        Task<CategoriaBebida> GetByDescricaoAsync(string descricao);
    }
}