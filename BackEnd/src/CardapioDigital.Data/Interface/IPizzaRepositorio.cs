using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface 
{
    public interface IPizzaRepositorio : IGeralRepositorio
    {
        Task<Pizza[]> GetAllAsync();
        Task<Pizza> GetByIdAsync(int id);
        Task<Pizza> GetBySaborAsync(string sabor);
    }
}