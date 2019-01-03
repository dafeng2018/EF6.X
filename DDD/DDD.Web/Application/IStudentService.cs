using DDD.Web.Domain.Entity;
using System.Linq;

namespace DDD.Web.Application
{
    public interface IStudentService
    {
        Student Get(int id);

        bool Add(string name);
    }
}