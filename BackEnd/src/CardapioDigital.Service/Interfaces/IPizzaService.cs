using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface IPizzaService
    {
        Task<PizzaDto> Add(PizzaDto pizzaDto);
        Task<PizzaDto> Update(PizzaDto pizzaDto);
        Task<bool> Delete(int id);
        Task<PizzaDtoGet[]> GetAllAsync();
        Task<PizzaDto> GetByIdAsync(int id);
        Task<PizzaDto> GetBySaborAsync(string sabor);
    }
}