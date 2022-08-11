using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface ICategoriaPizzaService
    {
        Task<CategoriaPizzaDto> Add(CategoriaPizzaDto categoriaPizzaDto);
        Task<CategoriaPizzaDto> Update(CategoriaPizzaDto categoriaPizzaDto);
        Task<bool> Delete(int id);
        Task<CategoriaPizzaDto[]> GetAllAsync();
        Task<CategoriaPizzaDto> GetByIdAsync(int id);
        Task<CategoriaPizzaDto> GetByDescricaoAsync(string descricao);
    }
}