using Microsoft.EntityFrameworkCore;
using CardapioDigitalWebAPI.Models;
using CardapioDigitalWebAPI.Interface;

namespace CardapioDigitalWebAPI.Data
{
    public class PizzasData : IPizzasData
    {
        private readonly DataContext _context;

        public PizzasData(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Pizzas[]> GetAllPizzasAsync()
        {
            IQueryable<Pizzas> query = _context.Pizzas;

            query = query.AsNoTracking()
                         .OrderBy(pizzas => pizzas.PIZ_NOME1);
            
            return await query.ToArrayAsync();
        }

        public async Task<Pizzas> GetPizzaAsyncById(int piz_id)
        {
            IQueryable<Pizzas> query = _context.Pizzas;

            query = query.AsNoTracking()
                         .OrderBy(pizzas => pizzas.PIZ_NOME1)
                         .Where(pizzas => pizzas.PIZ_ID1 == piz_id);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pizzas[]> GetAllPizzasAsyncByDesc(string piz_desc)
        {
            IQueryable<Pizzas> query = _context.Pizzas;

            query = query.AsNoTracking()
                         .OrderBy(pizzas => pizzas.PIZ_NOME1)
                         .Where(pizzas =>
                                EF.Functions.Like(pizzas.PIZ_DESC1, $"%{piz_desc}%"));
            
            return await query.ToArrayAsync();
        }
    }
}