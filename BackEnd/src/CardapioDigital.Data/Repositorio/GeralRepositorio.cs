using CardapioDigital.Data.Context;
using CardapioDigital.Data.Interface;

namespace CardapioDigital.Data.Repositorio
{
    public class GeralRepositorio : IGeralRepositorio
    {
        private readonly CardapioDigitalContext _context;

        public GeralRepositorio(CardapioDigitalContext context)
        {
            _context = context;
        }
        public void Add<T>(T model) where T : class
        {
            _context.Add<T>(model);
        }

        public void Delete<T>(T model) where T : class
        {
            _context.Remove<T>(model);
        }

        public void DeleteRange<T>(T[] model) where T : class
        {
            _context.RemoveRange(model);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T model) where T : class
        {
            _context.Update<T>(model);
        }
    }
}