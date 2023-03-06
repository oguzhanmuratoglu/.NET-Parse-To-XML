using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.DataAccess.Abstract;
using TestSolution.Entities.Concrete;

namespace TestSolution.DataAccess.Concrete.EntityFramework
{
    public class EfTestDal : EfEntityRepositoryBase<Test, TestSolutionContext>, ITestDal
    {
    }
}
