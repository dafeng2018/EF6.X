using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDD.Web.Infrastructure
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Rollback();
    }
}