using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface ITipoService
    {
        Task<TipoDto> Add(TipoDto tipoDto);
        Task<TipoDto> Update(TipoDto tipoDto);
        Task<bool> Delete(int id);
        Task<TipoDto[]> GetAllAsync();
        Task<TipoDto> GetByIdAsync(int id);
    }
}