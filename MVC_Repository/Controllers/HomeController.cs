using MVC_Repository.Domain.Concrete;
using MVC_Repository.Models;
using MVC_Repository.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Repository.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext db = new EFDbContext();
        public ActionResult Index()
        {
            var user = db.SysRoles.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        private IWeapon weapon;

        public HomeController(IWeapon weaponParam)
        {
            weapon = weaponParam;
        }

        public ActionResult Battle()
        {
            var warrior1 = new Samurai(new Sword());
            ViewBag.Res = warrior1.Attack("the evildoers");
            return View();
        }
    }
}