using CardapioDigital.Service.DTOs;

namespace CardapioDigital.Service.Interfaces
{
    public interface ICategoriaBebidaService
    {
        Task<CategoriaBebidaDto> Add(CategoriaBebidaDto categoriaBebidaDto);
        Task<CategoriaBebidaDto> Update(CategoriaBebidaDto categoriaBebidaDto);
        Task<bool> Delete(int id);
        Task<CategoriaBebidaDto[]> GetAllAsync();
        Task<CategoriaBebidaDto> GetByIdAsync(int id);
        Task<CategoriaBebidaDto> GetByDescricaoAsync(string descricao);
    }
}