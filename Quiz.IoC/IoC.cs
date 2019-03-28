using Quiz.Common.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.IoC
{
    public static class IoC
    {
        public static IIocProvider Provider { get; set; }

        static IoC() {

            if (String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["Quiz.IoC.DefaultProvider"]))
                throw new System.Configuration.ConfigurationErrorsException("Missing parameter Quiz.IoC.DefaultProvider");

            Provider = (IIocProvider)Type.GetType(System.Configuration.ConfigurationManager.AppSettings["Quiz.IoC.DefaultProvider"])
                .GetConstructor(new Type[0])
                .Invoke(new object[0]);


                        
        }
    }
}
