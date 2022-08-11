using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class BordaRepositorio : GeralRepositorio, IBordaRepositorio
    {
        private readonly CardapioDigitalContext _context;
        public BordaRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Borda[]> GetAllAsync()
        {
            try
            {
                IQueryable<Borda> query = _context.Bordas.AsNoTracking();

                return await query.OrderBy(borda => borda.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Borda> GetByDescricaoAsync(string descricao)
        {
            try
            {
                IQueryable<Borda> query = _context.Bordas.AsNoTracking();

                return await query.Where(borda => borda.Descricao == descricao)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Borda> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<Borda> query = _context.Bordas.AsNoTracking();

                return await query.Where(borda => borda.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}