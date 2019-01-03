using Autofac;
using EF.Data;
using EF.Data.Configuration;
using EF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFUnitOfWorkDI.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EFDbContext>().As<IDbContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>();

            base.Load(builder);
        }
    }
}