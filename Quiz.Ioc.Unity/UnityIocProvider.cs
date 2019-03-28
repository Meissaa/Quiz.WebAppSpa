using Quiz.Common.Entities.IoC;
using Quiz.Common.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Quiz.IoC.Unity
{
    public class UnityIocProvider : IIocProvider
    {
        private IIocContainer _container { get; set; }

        public UnityIocProvider() {

            _container = new UnityIocContainer();
        }
        public IIocContainer GetContainer()
        {
            return _container;
        }
    }
}
