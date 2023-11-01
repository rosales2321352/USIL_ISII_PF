namespace WebApp.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
