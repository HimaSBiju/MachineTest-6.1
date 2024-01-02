using MachineTest_6._1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MachineTest_6._1.Repository
{
    public interface IPurchaseRepository
    {
        //Get All Purchase Orders
        Task<List<PurchaseOrder>> GetAllPurchaseOrders();

        //Add Purchase Order
        Task<int> AddPurchaseOrder(PurchaseOrder purchase);

        //Update Purchase Orders
        Task UpdatePurchaseOrder(PurchaseOrder purchase);

        //Delete Purchase Order
        Task<int> DeletePurchaseOrder(int? id);

        //Get Purchase Order By ID
        Task<PurchaseOrder> GetPurchaseOrderById(int? id);
    }
}
