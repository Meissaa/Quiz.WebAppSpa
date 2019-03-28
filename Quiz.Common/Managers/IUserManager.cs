using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Managers
{
    public interface IUserManager : IDisposable
    {
        User CreateUser(User user);
    }
}
