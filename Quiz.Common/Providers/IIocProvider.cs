using Quiz.Common.Entities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Providers
{
    public interface IIocProvider
    {
        IIocContainer GetContainer();
    }
}
