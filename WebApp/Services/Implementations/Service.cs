using WebApp.Data;

namespace WebApp.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<TEntity> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
    }
}
