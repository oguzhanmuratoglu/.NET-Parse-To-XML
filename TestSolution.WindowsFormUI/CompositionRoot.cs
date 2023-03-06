﻿using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolution.WindowsFormUI
{
    public class CompositionRoot
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
