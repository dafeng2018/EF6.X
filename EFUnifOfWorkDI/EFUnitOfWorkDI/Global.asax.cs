﻿using AutoMapper;
using EFUnitOfWorkDI.App_Start;
using EFUnitOfWorkDI.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EFUnitOfWorkDI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //初始化Autofac容器
            AutofacConfig.ConfigureContainer();

            //初始化AutoMapper映射配置
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //只添加Razor视图引擎，去除对Web form视图查找
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
