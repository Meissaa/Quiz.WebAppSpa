using log4net;
using Quiz.Common;
using Quiz.Common.Exceptions;
using Quiz.Common.Managers;
using Quiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Business.Managers
{
    public class AuthManager : IAuthManager
    {
        private static ILog _log;
        private static User _loggedUser;
        private QuizDbContext _db = new QuizDbContext();

        public AuthManager() {

            _log = LogManager.GetLogger(this.GetType().FullName);
        }

        public bool IsUserLogged()
        {
            return (User)_loggedUser != null;
        }

        public void Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new AuthException("Invalid username or password");

            var user = _db.Users.Where(e => e.Username == username && e.Password == password).FirstOrDefault();

            if (user == null)
                throw new AuthException("Invalid username or password");

            _loggedUser = user;

        }

        public void Logout()
        {
            if (!IsUserLogged())
                throw new AuthException("No user currently logged in");

            _loggedUser = null;
        }

        public User GetLoggedUser()
        {
            return _loggedUser;
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }  
    }
}
