using MachineTest_6._1.Models;
using System.Linq;

namespace MachineTest_6._1.Repository
{
    public class UserLogin:IUserLogin
    {
        private readonly SalesDBContext _dbContext;

        public UserLogin(SalesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Find user by credentials
        public Login ValidateUser(string username, string password)
        {
            if (_dbContext != null)
            {
                Login user = _dbContext.Login.FirstOrDefault(user => user.UserName == username && user.UserPassword == password);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        #endregion
    }
}
