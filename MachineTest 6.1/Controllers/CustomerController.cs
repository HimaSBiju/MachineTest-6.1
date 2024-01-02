using MachineTest_6._1.Models;
using MachineTest_6._1.Repository;
using MachineTest_6._1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest_6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;   
        }

        #region List All Customers

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerRegistration>>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }
        #endregion

        #region Add Customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRegistration customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customerId = await _customerRepository.AddCustomer(customer);
                    if (customerId > 0)
                    {
                        return Ok(customerId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update Customer Details
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerRegistration customer)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    await _customerRepository.UpdateCustomer(customer);
                    return Ok(customer);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete Customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            try
            {
                var customerId = await _customerRepository.DeleteCustomer(id);
                if (customerId > 0)
                {
                    return Ok(customerId);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region Get Customer By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerRegistration>> GetCustomerById(int? id)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get All Customer Orders
        [HttpGet]
        [Route("CustomerOrders")]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> GetAllCustomerOrders()
        {
            return await _customerRepository.GetAllCustomerOrders();
        }
        #endregion
    }
}
