using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using TestSolution.DataAccess.Abstract;
using TestSolution.Entities.Concrete;
using TestSolution.Business.Abstract;
using Ninject;
using TestSolution.Business.Concrete;

namespace TestSolutionConsoleUI.Services
{
    public class ConsoleServices
    {
        

        private ITestManager _testManager;

        public ConsoleServices()
        {
        }

        public ConsoleServices(ITestManager testManager)
        {
            _testManager = testManager;
        }
        public void DatabaseLoading()
        {
            Console.WriteLine("ID    SGKKOD    TCKN                  Soyad             Ad             BabaAdi               Tutar");
            var data = _testManager.GetAll();
            foreach (var item in data)
            {
                Console.WriteLine(item.Id+ "    " + item.SGKKOD + "    " + item.TCKN + "               "
                    + item.Soyad + "          " + item.Ad + "             " + item.BabaAdi + "                  " + item.Tutar);
            }
            Console.WriteLine("\nVeritabanındaki Veriler Başarılı Bir Şekilde Konsola Aktarılmıştır!");
            Console.Read();
        }

        public void XmlLoading()
        {
            var filePath = "../../../../TestSolution.Business/GivenData/test.xml";
            var sgkData = XElement.Load(filePath);
            var data = sgkData.Descendants("SGKIstek");
            Console.WriteLine("SGKKOD    TCKN               Soyad          Ad             BabaAdi               Tutar");
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Element("SGKKOD").Value}" + "   " + $"{item.Element("TCKN").Value}" + "        " +
                    $"{item.Element("Soyad").Value}" + "        " + $"{item.Element("Ad").Value}" + "             " +
                    $"{item.Element("BabaAdi").Value}" + "                  " + $"{item.Element("Tutar").Value}");
            }
        }

        public void XmlToDatabaseLoading()
        {
            
            var entities = _testManager.GetAll();
            _testManager.DeleteAll(entities);
            var doc = new XmlDocument();
            doc.Load("../../../../TestSolution.Business/GivenData/test.xml");
            XmlNodeList nodes = doc.SelectNodes("//SGKIstekListe/SGKIstek");
            foreach (XmlNode node in nodes)
            {
                _testManager.Add(new Test
                {
                    SGKKOD = int.Parse(node.SelectSingleNode("SGKKOD").InnerText),
                    TCKN = long.Parse(node.SelectSingleNode("TCKN").InnerText),
                    Soyad = node.SelectSingleNode("Soyad").InnerText,
                    Ad = node.SelectSingleNode("Ad").InnerText,
                    BabaAdi = node.SelectSingleNode("BabaAdi").InnerText,
                    Tutar = node.SelectSingleNode("Tutar").InnerXml
                });

            }
            Console.WriteLine("İşlem Başarıyla Gerçekleşti");
            
        }
    }
}
