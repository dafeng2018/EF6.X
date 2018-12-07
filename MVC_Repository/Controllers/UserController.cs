using MVC_Repository.Domain.Entities;
using MVC_Repository.Domain.Repositories;
using MVC_Repository.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository.Controllers
{
    public class UserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: User
        public ActionResult Index()
        {
            var users = unitOfWork.SysUserInfoRepository.Get(filter: q => q.Name.Contains("b"), orderby: q => q.OrderByDescending(u => u.Name));
            return View(users);
        }
        public ActionResult Edit(int id)
        {
            var user = unitOfWork.SysUserInfoRepository.GetByID(id);

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(SysUserInfo user)
        {
            if (ModelState.IsValid)
            {
                var updateUser = unitOfWork.SysUserInfoRepository.GetByID(user.Id);
                if (ReferenceEquals(updateUser, null))
                {
                    return Content("<script  type='text/javascript'>alert('提交参数不正确!');location.href='/';</script>");
                }
                else
                {
                    updateUser.Name = user.Name;
                    updateUser.Password = user.Password;
                    updateUser.CName = user.CName;
                    updateUser.Description = user.Description;
                    updateUser.ModifiedDate = DateTime.Now;
                    unitOfWork.SysUserInfoRepository.Update(updateUser);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
    }
}