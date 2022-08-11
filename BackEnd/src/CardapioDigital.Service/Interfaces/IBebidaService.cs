using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface IBebidaService
    {
        Task<BebidaDto> Add(BebidaDto bebidaDto);
        Task<BebidaDto> Update(BebidaDto bebidaDto);
        Task<bool> Delete(int id);
        Task<BebidaDto[]> GetAllAsync();
        Task<BebidaDto> GetByIdAsync(int id);
        Task<BebidaDto> GetByNomeAsync(string nome);

    }
}