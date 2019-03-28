using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Common.Managers
{
    public interface IAuthManager :IDisposable
    {
        void Login(string username, string password);
        bool IsUserLogged();
        void Logout();
        User GetLoggedUser();
    }
}
