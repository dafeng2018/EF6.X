using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDD.Web.Domain.Entity;
using DDD.Web.Infrastructure;
using DDD.Web.Respository;

namespace DDD.Web.Application
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;
        private IStudentRepository _studentRepository;

        public StudentService(IUnitOfWork unitOfWork,
            IStudentRepository studentRepository)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
        }

        public IQueryable<Student> Get(int id)
        {
            return _studentRepository.Get(id);
        }

        public bool Add(string name)
        {
            var student = new Student { Name = name };

            _unitOfWork.RegisterNew(student);
            return _unitOfWork.Commit();
        }
    }
}