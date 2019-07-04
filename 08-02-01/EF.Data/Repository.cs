using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EF.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext context;
        private IDbSet<TEntity> entities;
        public Repository(IDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = Entities;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).FirstOrDefault();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, ICollection<string> includes)
        {
            IQueryable<TEntity> query = Entities;
            query = query.Where(predicate);
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            TEntity result = query.FirstOrDefault();

            return result;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            context.SaveChanges();

        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, IQueryable<string> includes)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, IQueryable<string> includes)
        {
            throw new NotImplementedException();
        }

        //public void Delete(TEntity entity)
        //{
        //    Entities.Remove(entity);
        //}

        //public TEntity GetById(object id)
        //{
        //    return Entities.Find(id);
        //}

        //public void Insert(TEntity entity)
        //{
        //    Entities.Add(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //    context.Entry<TEntity>(entity).State = EntityState.Modified;

        //}

        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return Entities;
            }
        }
        private IDbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<TEntity>();
                }
                return entities;
            }
        }

    }
}
