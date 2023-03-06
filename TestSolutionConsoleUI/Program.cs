using Ninject;
using TestSolution.Business.Abstract;
using TestSolution.Business.Concrete;
using TestSolution.DataAccess.Abstract;
using TestSolution.DataAccess.Concrete.EntityFramework;
using TestSolutionConsoleUI.Services;

namespace TestSolutionConsoleUI
{
    public class Program
    {

        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ITestManager>().To<TestManager>().InSingletonScope();
            kernel.Bind<ITestDal>().To<EfTestDal>().InSingletonScope();
            var _consoleServices = new ConsoleServices(kernel.Get<ITestManager>());
            _consoleServices.XmlLoading();
            Console.WriteLine("\nMerhaba,Yukarıda Verilen Xml Dosyalarının Yansımasını Görmektesiniz.\nVerilen Dosyalar Veritabanına Aktarılsın Mı?\n(YES or NO)");
            if (Console.ReadLine() == "YES")
            {
                _consoleServices.XmlToDatabaseLoading();
                Console.WriteLine("Veri Tabanındaki Verilere Erişmek İçin Herhangi Bir Tuşa Basınız.");
                Console.Read();
                _consoleServices.DatabaseLoading();
            }
            else
            {
                Console.WriteLine("Pekala, İsteğiniz Üzerine Xml Verileri Veritabanına Aktarılmayacaktır. Bizi Tercih Ettiğiniz İçin Teşekkür Ederiz");
            }

            Console.Read();
        }
    }
}