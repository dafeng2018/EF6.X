using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDD.Web.Domain.Entity;
using DDD.Web.Infrastructure;

namespace DDD.Web.Respository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbContext dbContext)
                   : base(dbContext)
        {
        }

        public Student GetByName(string name)
        {
            return base._dbContext.Set<Student>().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}