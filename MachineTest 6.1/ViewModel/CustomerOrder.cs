using System;

namespace MachineTest_6._1.ViewModel
{
    public class CustomerOrder
    {
        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
    }
}
