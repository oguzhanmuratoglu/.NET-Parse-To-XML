using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSolution.Entities.Concrete;

namespace TestSolution.Business.Abstract
{
    public interface ITestManager
    {
        List<Test> GetAll();
        void Add(Test test);
        void Update(Test test);
        void Delete(int testId);
        void DeleteAll(List<Test> testes);

        Test GetById(int testId);
    }
}
