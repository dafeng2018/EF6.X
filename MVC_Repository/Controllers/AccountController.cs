using MVC_Repository.Domain.Entities;
using MVC_Repository.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Repository.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Account
        public ActionResult Login()
        {
            FormsAuthentication.SignOut();
            TempData["ReturnUrl"] = Convert.ToString(Request["ReturnUrl"]);
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string userName = fc["UserName"];
            string password = fc["Password"];
            string returnUrl = Convert.ToString(TempData["ReturnUrl"]);
            bool remberMe = fc["chkRemberMe"] == null ? false : true;
            SysUserInfo user = unitOfWork.SysUserInfoRepository.Get(filter: u => u.Name == userName && u.Password == password).FirstOrDefault();
            unitOfWork.Dispose();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(userName, remberMe);
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("~/");
                }
            }
            else
            {
                ViewBag.LoginState = "User name or password incorrect";
            }
            return View();
        }
    }
}