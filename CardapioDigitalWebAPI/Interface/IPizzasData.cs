using CardapioDigitalWebAPI.Models;

namespace CardapioDigitalWebAPI.Interface
{
    public interface IPizzasData
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Pizzas[]> GetAllPizzasAsync(); 
        Task<Pizzas> GetPizzaAsyncById(int piz_id);
        Task<Pizzas[]> GetAllPizzasAsyncByDesc(string piz_desc);
     }
}