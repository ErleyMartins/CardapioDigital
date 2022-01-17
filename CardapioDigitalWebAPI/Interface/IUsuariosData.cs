using CardapioDigitalWebAPI.Models;

namespace CardapioDigitalWebAPI.Interface
{
    public interface IUsuariosData
    {
        void Add<T> (T entity) where T : class;
        void Update<T> (T entity) where T : class;
        void Delete<T> (T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Usuarios> Login(string usr_login, string usr_password);
        Task<Usuarios> GetUsuarioAsyncById(int usr_id);
        Task<Usuarios> GetUsuarioAsyncByLogin(string usr_login);
        Task<Usuarios[]> GetAllUsuarioAsync();
    }
}