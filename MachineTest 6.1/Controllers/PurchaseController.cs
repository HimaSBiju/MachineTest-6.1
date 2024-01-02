using MachineTest_6._1.Models;
using MachineTest_6._1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest_6._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        #region List All Purchase Orders

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetAllPurchaseOrders()
        {
            return await _purchaseRepository.GetAllPurchaseOrders();
        }
        #endregion

        #region Add Purchase Order
        [HttpPost]
        public async Task<IActionResult> AddPurchaseOrder([FromBody] PurchaseOrder purchase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var purchaseId = await _purchaseRepository.AddPurchaseOrder(purchase);
                    if (purchaseId > 0)
                    {
                        return Ok(purchaseId);
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

        #region Update Purchase Order
        [HttpPut]
        public async Task<IActionResult> UpdatePurchaseOrder([FromBody] PurchaseOrder purchase)
        {
            //check the validation of the body
            if (ModelState.IsValid)
            {
                try
                {
                    await _purchaseRepository.UpdatePurchaseOrder(purchase);
                    return Ok(purchase);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Delete Purchase Order
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrder(int? id)
        {
            try
            {
                var orderId = await _purchaseRepository.DeletePurchaseOrder(id);
                if (orderId > 0)
                {
                    return Ok(orderId);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion

        #region Get Purchase Order By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrderById(int? id)
        {
            try
            {
                var order = await _purchaseRepository.GetPurchaseOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
