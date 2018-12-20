using MVC_Repository.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVC_Repository.Roles
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] AuthRoles { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionDescriptor.ActionName;
            string roles = GetXMLRoles.GetActionRoles(actionName, controllerName);
            if (!string.IsNullOrWhiteSpace(roles))
            {
                this.AuthRoles = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                this.AuthRoles = new string[] { };
            }
            base.OnAuthorization(filterContext);
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentException("HttpContext");
            }
            if (AuthRoles == null || AuthRoles.Length == 0)
            {
                return true;
            }
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            //return base.AuthorizeCore(httpContext);
            string currentUser = httpContext.User.Identity.Name;
            string query = @"select Name from SysRoles where id in (select SysRoleID from SysUserRoles where SysUserID = (select ID from SysUserInfoes where Name = @userName))";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@userName",currentUser)
            };
            var userRoles = new List<string>();
            using (EFDbContext db = new EFDbContext())
            {
                userRoles = db.Database.SqlQuery<string>(query, paras).ToList();
            }
            for (int i = 0; i < AuthRoles.Length; i++)
            {
                if (userRoles.Contains(AuthRoles[i]) == true)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static class GetXMLRoles
    {
        public static string GetActionRoles(string action, string controller)
        {
            XElement rootElement = XElement.Load(HttpContext.Current.Server.MapPath("~/Config/") + "ActionRoles.xml");
            XElement controllerElement = FindElementByAttribute(rootElement, "Controller", controller);
            if (controllerElement != null)
            {
                XElement actionElement = FindElementByAttribute(controllerElement, "Action", action);
                if (actionElement != null)
                {
                    return actionElement.Value;

                }
            }
            return "";
        }

        public static XElement FindElementByAttribute(XElement xElement, string tagName, string attribute)
        {
            return xElement.Elements(tagName).FirstOrDefault(x => x.Attribute("name").Value.Equals(attribute, StringComparison.OrdinalIgnoreCase));
        }
    }
}