using Microsoft.EntityFrameworkCore;
using CardapioDigitalWebAPI.Models;
using CardapioDigitalWebAPI.Interface;

namespace CardapioDigitalWebAPI.Data
{
    public class BebidasData : IBebidasData
    {
        private readonly DataContext _context;
        public BebidasData(DataContext context)
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

        public async Task<Bebidas[]> GetAllBebidasAsync()
        {
            IQueryable<Bebidas> query = _context.Bebidas;

            query = query.AsNoTracking()
                         .OrderBy(bebidas => bebidas.BEB_NOME1);
            
            return await query.ToArrayAsync();
        }

        public async Task<Bebidas> GetBebidaAsyncById(int beb_id)
        {
            IQueryable<Bebidas> query = _context.Bebidas;

            query = query.AsNoTracking()
                         .OrderBy(bebidas => bebidas.BEB_NOME1)
                         .Where(bebidas => bebidas.BEB_ID1 == beb_id);
            
            return await query.FirstOrDefaultAsync();
        }
       
    }
}