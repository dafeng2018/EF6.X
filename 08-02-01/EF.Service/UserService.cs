using EF.Core.Data;
using EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Service
{
    //public class UserService : IUserService
    //{
    //    private IRepository<User> userRepository;
    //    private IRepository<UserProfile> userProfileRepository;

    //    public UserService(IRepository<User> userRepository, IRepository<UserProfile> userProfileRepository)
    //    {
    //        this.userRepository = userRepository;
    //        this.userProfileRepository = userProfileRepository;
    //    }

    //    public IQueryable<User> GetUsers()
    //    {
    //        return userRepository.GetAll();
    //    }

    //    public User GetUser(long id)
    //    {
    //        return userRepository.GetById(id);
    //    }

    //    public void InsertUser(User user)
    //    {
    //        userRepository.Add(user);
    //    }

    //    public void UpdateUser(User user)
    //    {
    //        userRepository.Update(user);
    //    }

    //    public void DeleteUser(User user)
    //    {
    //        userProfileRepository.Remove(user.UserProfile);
    //        userRepository.Remove(user);
    //    }

    //}

    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {

        }
    }
}
