using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface ITipoRepositorio : IGeralRepositorio
    {
        Task<Tipo[]> GetAllAsync();
        Task<Tipo> GetByIdAsync(int id);
    }
}