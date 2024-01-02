using System;
using System.Collections.Generic;

namespace MachineTest_6._1.Models
{
    public partial class PurchaseOrder
    {
        public int OId { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public int? CId { get; set; }
        public int? VId { get; set; }

        public virtual CustomerRegistration C { get; set; }
        public virtual Vendor V { get; set; }
    }
}
