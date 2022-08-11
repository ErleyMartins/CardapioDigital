using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;
using CardapioDigital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardapioDigital.Data.Repositorio
{
    public class PizzaRepositorio : GeralRepositorio, IPizzaRepositorio
    {
        private readonly CardapioDigitalContext _context;

        public PizzaRepositorio(CardapioDigitalContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pizza[]> GetAllAsync()
        {
            try
            {
                IQueryable<Pizza> query = _context.Pizzas.AsNoTracking();

                return await query.Include(pizza => pizza.CategoriaPizza)
                                  .Include(pizza => pizza.Tipo)
                                  .Include(pizza => pizza.PrecosPizzas)
                                  .ThenInclude(preco => preco.Tamanho)
                                  .OrderBy(pizza => pizza.Nome)
                                  .ToArrayAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pizza> GetByIdAsync(int id)
        {
            try
            {
                IQueryable<Pizza> query = _context.Pizzas.AsNoTracking();

                return await query.Where(pizza => pizza.Id == id)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pizza> GetBySaborAsync(string sabor)
        {
            try
            {
                IQueryable<Pizza> query = _context.Pizzas.AsNoTracking();

                return await query.Where(pizza => pizza.Nome == sabor)
                                  .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}