using Quiz.Common;
using Quiz.Common.Managers;
using Quiz.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using Quiz.Data;

namespace Quiz.Business
{
    public class UserManager : IUserManager
    {
        private static ILog _log;
        private QuizDbContext _db = new QuizDbContext();

        public UserManager() {

            _log = LogManager.GetLogger(this.GetType().FullName);
        }

        public User CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (string.IsNullOrEmpty(user.Username))
                throw new ArgumentNullException("username");
            if (string.IsNullOrEmpty("password"))
                throw new ArgumentNullException("password");

            if (_db.Users.Where(u => u.Username == user.Username).FirstOrDefault() != null)
                throw new UserAlreadyExistsException(string.Format("User '{0}' already exists.", user.Username));

            var result = _db.Users.Add(user);
            _db.SaveChanges();

            return result;          
        }

        public void Dispose()
        {
            if (_db != null)
                _db.Dispose();
        }
    }
}
