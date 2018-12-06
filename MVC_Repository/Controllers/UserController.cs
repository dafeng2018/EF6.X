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
    }
}