using MachineTest_6._1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest_6._1.Repository
{
    public class PurchaseRepository:IPurchaseRepository
    {
        private readonly SalesDBContext _context;
        public PurchaseRepository(SalesDBContext context)
        {
            _context = context;
        }

        #region List All Purchase Orders
        public async Task<List<PurchaseOrder>> GetAllPurchaseOrders()
        {
            if (_context != null)
            {
                return await _context.PurchaseOrder.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Add Purchase Order
        public async Task<int> AddPurchaseOrder(PurchaseOrder purchase)
        {
            if (_context != null)
            {
                await _context.PurchaseOrder.AddAsync(purchase);
                await _context.SaveChangesAsync();
                return purchase.OId;
            }
            return 0;
        }
        #endregion

        #region Update Purchase Order
        public async Task UpdatePurchaseOrder(PurchaseOrder purchase)
        {
            if (_context != null)
            {
                _context.Entry(purchase).State = EntityState.Modified;
                _context.PurchaseOrder.Update(purchase);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Delete Purchase Order
        public async Task<int> DeletePurchaseOrder(int? id)
        {
            if (_context != null)
            {
                var purchase = await _context.PurchaseOrder.FirstOrDefaultAsync(emp => emp.OId == id);

                if (purchase != null)
                {
                    _context.PurchaseOrder.Remove(purchase);
                    await _context.SaveChangesAsync();
                    return purchase.OId;
                }
            }
            return 0;

        }
        #endregion

        #region Get Purchase Order by Id
        public async Task<PurchaseOrder> GetPurchaseOrderById(int? id)
        {
            if (_context != null)
            {
                var purchase = await _context.PurchaseOrder.FindAsync(id);
                return purchase;
            }
            return null;
        }
        #endregion
    }
}
