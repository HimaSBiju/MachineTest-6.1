using System;
using System.Collections.Generic;

namespace MachineTest_6._1.Models
{
    public partial class Login
    {
        public Login()
        {
            CustomerRegistration = new HashSet<CustomerRegistration>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<CustomerRegistration> CustomerRegistration { get; set; }
    }
}
