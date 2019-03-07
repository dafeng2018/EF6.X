using EF.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;

        }

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

        public IQueryable<TEntity> TEntityable
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
