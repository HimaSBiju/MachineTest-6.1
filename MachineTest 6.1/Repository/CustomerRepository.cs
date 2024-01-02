using MachineTest_6._1.Models;
using MachineTest_6._1.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MachineTest_6._1.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly SalesDBContext _context;
        public CustomerRepository(SalesDBContext context)
        {
            _context = context;
        }

        #region List All Customers
        public async Task<List<CustomerRegistration>> GetAllCustomers()
        {
            if (_context != null)
            {
                return await _context.CustomerRegistration.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Customer
        public async Task<int> AddCustomer(CustomerRegistration customer)
        {
            if (_context != null)
            {
                await _context.CustomerRegistration.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer.CId;
            }
            return 0;
        }
        #endregion

        #region Update Customer Details
        public async Task UpdateCustomer(CustomerRegistration customer)
        {
            if (_context != null)
            {
                _context.Entry(customer).State = EntityState.Modified;
                _context.CustomerRegistration.Update(customer);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete Customer
        public async Task<int> DeleteCustomer(int? id)
        {
            if (_context != null)
            {
                var customer = await _context.CustomerRegistration.FirstOrDefaultAsync(emp => emp.CId == id);

                if (customer != null)
                {
                    //Delete
                    _context.CustomerRegistration.Remove(customer);

                    //Commit
                    await _context.SaveChangesAsync();
                    return customer.CId;
                }

            }
            return 0;

        }
        #endregion

        #region Get Customer by Id
        public async Task<CustomerRegistration> GetCustomerById(int? id)
        {
            if (_context != null)
            {
                var customer = await _context.CustomerRegistration.FindAsync(id);
                return customer;
            }
            return null;
        }
        #endregion

        #region Get Customer Orders
        public async Task<List<CustomerOrder>> GetAllCustomerOrders()
        {
            if (_context != null)
            {
                //LINQ
                return await (from c in _context.CustomerRegistration              
                              from o in _context.PurchaseOrder
                              where c.CId == o.CId
                              select new CustomerOrder
                              {
                                  CId = c.CId,
                                  FirstName = c.FirstName,
                                  LastName = c.LastName,
                                  Gender = c.Gender,
                                  Address = c.Address,
                                  PhoneNumber = c.PhoneNumber,
                                  PurchaseOrderNumber=o.PurchaseOrderNumber,
                                  ItemName=o.ItemName,
                                  Quantity=o.Quantity,
                                  DeliveryDate=o.DeliveryDate,
                                  Status=o.Status
                              }).ToListAsync();
            }
            return null;
        }
        #endregion
        
        
    }
}
