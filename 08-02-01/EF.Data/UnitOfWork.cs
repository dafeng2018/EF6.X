using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbContext context;
        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

    }
}
