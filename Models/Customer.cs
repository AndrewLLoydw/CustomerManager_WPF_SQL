using System;
using System.Collections.Generic;

namespace CustomerManager_WPF_SQL.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int AddressId { get; set; }
        public int ErrandId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual CustomerErrand Errand { get; set; } = null!;
    }
}
