using CardapioDigital.Domain.Model;

namespace CardapioDigital.Data.Interface
{
    public interface ITamanhoRepositorio : IGeralRepositorio
    {
        Task<Tamanho[]> GetAllAsync();
        Task<Tamanho> GetByIdAsync(int id);
        Task<Tamanho> GetByDescricaoAsync(string descricao);
    }
}