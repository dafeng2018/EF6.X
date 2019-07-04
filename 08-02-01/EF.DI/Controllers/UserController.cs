using AutoMapper;
using AutoMapper.QueryableExtensions;
using EF.Core.Data;
using EF.DI.Models;
using EF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.DI.Controllers
{
    public class UserController : Controller
    {

        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            var users = userService.GetAll().ProjectTo<UserDTO>();
            return View(users);
        }
        [HttpGet]
        public ActionResult CreateEditUser(int? id)
        {
            var model = new UserDTO();
            if (id.HasValue && id.Value > 0)
            {
                var user = userService.GetById(id.Value);
                model = Mapper.Map<User, UserDTO>(user);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditUser(UserDTO model)
        {
            if (model.ID <= 0)
            {
                var userEntity = Mapper.Map<UserDTO, User>(model);
                userEntity.IP = Request.UserHostAddress;
                userEntity.CreatedTime = DateTime.Now;
                userEntity.ModifiedTime = DateTime.Now;
                userEntity.UserProfile.CreatedTime = DateTime.Now;
                userEntity.UserProfile.ModifiedTime = DateTime.Now;
                userService.Add(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                User userEntity = userService.GetById(model.ID);
                userEntity.UserName = model.UserName;
                userEntity.Email = model.Email;
                userEntity.Password = model.Password;
                userEntity.ModifiedTime = DateTime.UtcNow;
                userEntity.IP = Request.UserHostAddress;
                userEntity.UserProfile.FirstName = model.FirstName;
                userEntity.UserProfile.LastName = model.LastName;
                userEntity.UserProfile.Address = model.Address;
                userEntity.UserProfile.ModifiedTime = DateTime.UtcNow;
                userEntity.UserProfile.IP = Request.UserHostAddress;
                userService.Update(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }

            }
            return View(model);
        }
    }
}