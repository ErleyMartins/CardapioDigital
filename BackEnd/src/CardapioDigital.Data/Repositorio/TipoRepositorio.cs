using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class TipoRepositorio : GeralRepositorio, ITipoRepositorio
    {
        private readonly CardapioDigitalContext _context;

        public TipoRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tipo[]> GetAllAsync()
        {
            try
            {
                IQueryable<Tipo> query = _context.Tipos.AsNoTracking();

                return await query.OrderBy(tipo => tipo.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tipo> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<Tipo> query = _context.Tipos.AsNoTracking();

                return await query.Where(tipo => tipo.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}