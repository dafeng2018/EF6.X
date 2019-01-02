using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDD.Web.Domain.Entity;
using DDD.Web.Infrastructure;

namespace DDD.Web.Respository
{
    public class StudentRepository : IStudentRepository
    {
        private IQueryable<Student> _students;

        public StudentRepository(IDbContext dbContext)
        {
            _students = dbContext.Set<Student>();
        }

        public Student Get(int id)
        {
            return _students.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        IQueryable<Student> IRepository<Student>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}