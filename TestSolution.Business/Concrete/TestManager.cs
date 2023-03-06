using TestSolution.Business.Abstract;
using TestSolution.DataAccess.Abstract;
using TestSolution.Entities.Concrete;

namespace TestSolution.Business.Concrete
{
    public class TestManager : ITestManager
    {
        private ITestDal _testDal;

        public TestManager(ITestDal testDal)
        {
            _testDal = testDal;
        }
        public void Add(Test test)
        {
            _testDal.Add(test);
        }

        public void Delete(int testId)
        {
            _testDal.Delete(new Test {Id = testId });
        }

        public void DeleteAll(List<Test> testes)
        {
            _testDal.DeleteAll(testes);
        }

        public List<Test> GetAll()
        {
            return _testDal.GetAll();
        }

        public Test GetById(int testId)
        {
            return _testDal.Get(t=>t.Id == testId);
        }

        public void Update(Test test)
        {
            _testDal.Update(test);
        }
    }
}
