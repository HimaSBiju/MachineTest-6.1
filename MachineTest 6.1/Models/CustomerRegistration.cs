using System;
using System.Collections.Generic;

namespace MachineTest_6._1.Models
{
    public partial class CustomerRegistration
    {
        public CustomerRegistration()
        {
            PurchaseOrder = new HashSet<PurchaseOrder>();
        }

        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }
    }
}
