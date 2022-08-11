using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface ICategoriaPizzaRepositorio : IGeralRepositorio
    {
        Task<CategoriaPizza[]> GetAllAsync();
        Task<CategoriaPizza> GetByIdAsync(int id);
        Task<CategoriaPizza> GetByDescricaoAsync(string categoria);
    }
}