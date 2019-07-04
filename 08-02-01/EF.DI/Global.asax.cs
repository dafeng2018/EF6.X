using AutoMapper;
using EF.DI.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EF.DI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //初始化AutoMapper映射配置
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());


        }
    }
}
