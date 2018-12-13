using MVC_Repository.Domain.Entities;
using MVC_Repository.Domain.Repositories;
using MVC_Repository.Domain.UnitOfWork;
using MVC_Repository.Models;
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
        public ActionResult Index(int page = 1)
        {
            int pageSize = 1;

            var users = unitOfWork.SysUserInfoRepository.Get(orderby: q => q.OrderByDescending(u => u.Name));
            UsersListViewModel model = new UsersListViewModel
            {
                SysUserInfos = users.Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    TotalItems = users.Count()

                }
            };
            return View(model);
            //return View(users);
        }
        public ActionResult Edit(int id)
        {
            var user = unitOfWork.SysUserInfoRepository.GetByID(id);

            return View();
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
        public ActionResult SharedDate()
        {
            ViewBag.DateTime = DateTime.Now;
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialViewDate()
        {
            ViewBag.DateTime = DateTime.Now.AddMinutes(10);
            return View("_partialviewdate");
        }
    }
}
