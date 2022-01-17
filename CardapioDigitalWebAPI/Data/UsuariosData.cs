using Microsoft.EntityFrameworkCore;
using CardapioDigitalWebAPI.Models;
using CardapioDigitalWebAPI.Interface;

namespace CardapioDigitalWebAPI.Data
{
    public class UsuariosData : IUsuariosData
    {
        private readonly DataContext _context;
        public UsuariosData(DataContext context)
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

        public async Task<Usuarios> Login(string usr_login, string usr_password)
        {
            IQueryable<Usuarios> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario.USR_LOGIN1)
                         .Where(usuario => usuario.USR_LOGIN1 == usr_login && usuario.USR_PASSWORD1 == usr_password && usuario.USR_LOCKED1 == 0);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuarios> GetUsuarioAsyncById(int usr_id)
        {
            IQueryable<Usuarios> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(usuarios => usuarios.USR_LOGIN1)
                         .Where(usuarios => usuarios.USR_ID1 == usr_id);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuarios[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuarios> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(usuarios => usuarios.USR_LOGIN1);
            
            return await query.ToArrayAsync();
        }

        public async Task<Usuarios> GetUsuarioAsyncByLogin(string usr_login)
        {
            IQueryable<Usuarios> query = _context.Usuarios;

            query = query.AsNoTracking()
                         .OrderBy(usuarios => usuarios.USR_LOGIN1)
                         .Where(usuarios => usuarios.USR_LOGIN1 == usr_login);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}