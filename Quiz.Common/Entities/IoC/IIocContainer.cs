using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Entities.IoC
{
    public interface IIocContainer
    {
        T Resolve<T>();
        T Resolve<T>(string name);
        IIocContainer CreateChildContainer();
        object GetInternalContainer();
    }
}
