using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface IBordaService
    {
        Task<BordaDto> Add(BordaDto bordaDto);
        Task<BordaDto> Update(BordaDto bordaDto);
        Task<bool> Delete(int id);
        Task<BordaDto[]> GetAllAsync();
        Task<BordaDto> GetByIdAsync(int id);
        Task<BordaDto> GetByDescricaoAsync(string descricao);
    }
}