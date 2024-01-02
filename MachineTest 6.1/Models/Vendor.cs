using System;
using System.Collections.Generic;

namespace MachineTest_6._1.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int VId { get; set; }
        public string VendorName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
