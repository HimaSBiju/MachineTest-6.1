using MachineTest_6._1.Models;

namespace MachineTest_6._1.Repository
{
    public interface IUserLogin
    {
        //Get User By Credentials
        Login ValidateUser(string username, string password);
    }
}
