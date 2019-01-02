using DDD.Web.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DDD.Web.Infrastructure
{
    public class EFDbContext : DbContext, IDbContext
    {
        public EFDbContext() : base("name=db_school")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Teacher>();

            base.OnModelCreating(modelBuilder);
        }
    }
}