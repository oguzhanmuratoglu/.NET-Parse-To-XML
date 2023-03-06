using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Business.Abstract;
using TestSolution.Business.Concrete;
using TestSolution.DataAccess.Abstract;
using TestSolution.DataAccess.Concrete.EntityFramework;

namespace TestSolution.WindowsFormUI
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            Bind<ITestManager>().To<TestManager>();
            Bind<ITestDal>().To<EfTestDal>();
        }
    }
}
