using EF.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EFDbContext context;
        private bool disposed;
        private ConcurrentDictionary<string, object> repositories;
        public UnitOfWork()
        {
            context = new EFDbContext();
        }
        public UnitOfWork(EFDbContext context)
        {
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public Repository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new ConcurrentDictionary<string, object>();

            }
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var respositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
                repositories.TryAdd(type, respositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        public void RoolBack()
        {
            throw new NotImplementedException();
        }
    }
}
