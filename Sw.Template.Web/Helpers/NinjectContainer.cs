using Ayx.AvalonDI;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sw.Template.Web.Helpers
{
    public class NinjectContainer : IContainer
    {
        public StandardKernel Container { get; private set; }

        public NinjectContainer(StandardKernel container)
        {
            if (container == null)
                throw new NullReferenceException("container can't be null!");

            Container = container;
        }
        public object Get(Type type, string token = "")
        {
            return Container.Get(type);
        }

        public void Wire<T>(string token = "") where T : class
        {
            //do nothing
        }
    }
}
