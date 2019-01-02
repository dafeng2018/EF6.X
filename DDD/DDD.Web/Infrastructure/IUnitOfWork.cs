using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Web.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterNew<TEntity>(TEntity entity) where TEntity : class;
        void RegisterDirty<TEntity>(TEntity entity) where TEntity : class;
        void RegisterClean<TEntity>(TEntity entity) where TEntity : class;
        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;
        bool Commit();
        void Rollback();
    }
}