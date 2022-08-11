using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface IBebidaRepositorio : IGeralRepositorio
    {
        Task<Bebida[]> GetAllAsync();
        Task<Bebida> GetByIdAsync(int id);
        Task<Bebida> GetByNomeAsync(string nome);
    }
}