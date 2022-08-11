using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface IBordaRepositorio : IGeralRepositorio
    {
        Task<Borda[]> GetAllAsync();
        Task<Borda> GetByIdAsync(int id);
        Task<Borda> GetByDescricaoAsync(string descricao);
    }
}