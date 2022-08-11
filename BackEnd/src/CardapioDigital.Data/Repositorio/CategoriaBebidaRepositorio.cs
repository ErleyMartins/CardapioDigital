using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class CategoriaBebidaRepositorio : GeralRepositorio, ICategoriaBebidaRepositorio
    {
        private readonly CardapioDigitalContext _context;
        
        public CategoriaBebidaRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CategoriaBebida[]> GetAllAsync()
        {
            try
            {
                IQueryable<CategoriaBebida> query = _context.CategoriasBebidas.AsNoTracking();

                return await query.OrderBy(catBeb => catBeb.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebida> GetByDescricaoAsync(string descricao)
        {
            try
            {
                IQueryable<CategoriaBebida> query = _context.CategoriasBebidas.AsNoTracking();

                return await query.Where(catBeb => catBeb.Descricao == descricao)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaBebida> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<CategoriaBebida> query = _context.CategoriasBebidas.AsNoTracking();

                return await query.Where(catBeb => catBeb.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}