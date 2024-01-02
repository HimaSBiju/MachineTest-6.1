using MachineTest_6._1.Models;
using MachineTest_6._1.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest_6._1.Repository
{
    public interface ICustomerRepository
    {
        //Get All Customers
        Task<List<CustomerRegistration>> GetAllCustomers();

        //Add Customers
        Task<int> AddCustomer(CustomerRegistration customer);

        //Update Customer Details
        Task UpdateCustomer(CustomerRegistration customer);

        //Delete Customer
        Task<int> DeleteCustomer(int? id);

        //Get Customer By ID
        Task<CustomerRegistration> GetCustomerById(int? id);

        //Get All Customer Orders
        Task<List<CustomerOrder>> GetAllCustomerOrders();
        
    }
}
