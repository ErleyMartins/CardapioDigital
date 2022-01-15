using CardapioDigitalWebAPI.Models;

namespace CardapioDigitalWebAPI.Interface
{
    public interface IBebidasData
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Bebidas[]> GetAllBebidasAsync(); 
        Task<Bebidas> GetBebidaAsyncById(int beb_id);
    }
}