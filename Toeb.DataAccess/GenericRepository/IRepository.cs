using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toeb.DataAccess.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(object id);
        void Delete(TEntity entity);
        TEntity Find(object id);
        IEnumerable<TEntity> GetAll();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        //T is the real table passed in to the class inheriting this repository
        private DbContext _context;
        private DbSet<T> _dbEntity;
        public Repository(DbContext  context)
        {
            _context = context;//make a reference to the real database
            _dbEntity = _context.Set<T>(); //assign the actual table passed to the repostory
        }
        public void Delete(object id)
        {
            var entity = _dbEntity.Find(id);
            Delete(entity);
        }
        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }
        public T Find(object id)
        {
            return _dbEntity.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbEntity;
        }

        public void Insert(T model)
        {
            _dbEntity.Add(model);
            _context.SaveChanges();
        }


        public void Update(T model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
