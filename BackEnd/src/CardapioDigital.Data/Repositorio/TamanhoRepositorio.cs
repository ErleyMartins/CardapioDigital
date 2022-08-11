using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class TamanhoRepositorio : GeralRepositorio, ITamanhoRepositorio
    {
        private readonly CardapioDigitalContext _context;

        public TamanhoRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tamanho[]> GetAllAsync()
        {
            try
            {
                IQueryable<Tamanho> query = _context.Tamanhos.AsNoTracking();

                return await query.OrderBy(tamanho => tamanho.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tamanho> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<Tamanho> query = _context.Tamanhos.AsNoTracking();

                return await query.Where(tamanho => tamanho.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tamanho> GetByDescricaoAsync(string descricao)
        {
            try
            {
                IQueryable<Tamanho> query = _context.Tamanhos.AsNoTracking();

                return await query.Where(tamanho => tamanho.Descricao == descricao)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}