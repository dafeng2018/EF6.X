using DDD.Web.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Web.Respository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : BaseEntity
    {
        IQueryable<TAggregateRoot> Get(int id);

        IQueryable<TAggregateRoot> GetAll();
    }
}
