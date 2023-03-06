using Ninject;
using System.Reflection;
using TestSolution.Business.Abstract;
using TestSolution.Business.Concrete;
using TestSolution.DataAccess.Abstract;
using TestSolution.DataAccess.Concrete.EntityFramework;

namespace TestSolution.WindowsFormUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            CompositionRoot.Wire(new ApplicationModule());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(CompositionRoot.Resolve<Form1>());

        }
    }
}