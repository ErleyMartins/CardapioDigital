namespace CardapioDigital.Data.Interface
{
    public interface IGeralRepositorio
    {
        void Add<T>(T model) where T : class;
        void Update<T>(T model) where T : class;
        void Delete<T>(T model) where T : class;
        void DeleteRange<T>(T[] model) where T : class;
        Task<bool> SaveChangesAsync();
    }
}