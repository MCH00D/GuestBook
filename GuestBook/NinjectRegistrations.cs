using GuestBook.DataAccessLayer;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestBook
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<EfRepository>();
        }
    }
}