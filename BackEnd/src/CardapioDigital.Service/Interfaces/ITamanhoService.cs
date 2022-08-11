using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface ITamanhoService
    {
        Task<TamanhoDto> Add(TamanhoDto tamanhoDto);
        Task<TamanhoDto> Update(TamanhoDto tamanhoDto);
        Task<bool> Delete(int id);
        Task<TamanhoDto[]> GetAllAsync();
        Task<TamanhoDto> GetByIdAsync(int id);
        Task<TamanhoDto> GetByDescricaoAsync(string descricao);
    }
}