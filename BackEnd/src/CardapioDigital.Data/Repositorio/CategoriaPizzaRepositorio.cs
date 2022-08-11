using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class CategoriaPizzaRepositorio : GeralRepositorio, ICategoriaPizzaRepositorio
    {
        private readonly CardapioDigitalContext _context;
        
        public CategoriaPizzaRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;   
        }

        public async Task<CategoriaPizza[]> GetAllAsync()
        {
            try
            {
                IQueryable<CategoriaPizza> query = _context.CategoriasPizzas.AsNoTracking();

                return await query.OrderBy(catPizza => catPizza.Id)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizza> GetByDescricaoAsync(string categoria)
        {
            try
            {
                IQueryable<CategoriaPizza> query = _context.CategoriasPizzas.AsNoTracking();

                return await query.OrderBy(catPizza => catPizza.Categoria == categoria)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaPizza> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<CategoriaPizza> query = _context.CategoriasPizzas.AsNoTracking();

                return await query.OrderBy(catPizza => catPizza.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}