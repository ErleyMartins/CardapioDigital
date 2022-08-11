using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class BebidaRepositorio : GeralRepositorio, IBebidaRepositorio
    {
        private readonly CardapioDigitalContext _context;
        public BebidaRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Bebida[]> GetAllAsync()
        {
            try
            {
                IQueryable<Bebida> query = _context.Bebidas.AsNoTracking();

                return await query.Include(bebida => bebida.CategoriaBebida)
                                  .OrderBy(bebida => bebida.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bebida> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<Bebida> query = _context.Bebidas.AsNoTracking();

                return await query.Include(bebida => bebida.CategoriaBebida)
                                  .Where(bebida => bebida.Id == id)
                                  .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Bebida> GetByNomeAsync(string nome)
        {
            try
            {
                IQueryable<Bebida> query = _context.Bebidas.AsNoTracking();

                return await query.Include(bebida => bebida.CategoriaBebida)
                                  .Where(bebida => bebida.Nome == nome)
                                  .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}