using System;
using System.Collections.Generic;

namespace CustomerManager_WPF_SQL.Models
{
    public partial class CustomerErrand
    {
        public CustomerErrand()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string ErrandTitle { get; set; } = null!;
        public string ErrandDescription { get; set; } = null!;
        public string ErrandCreatedTime { get; set; } = null!;
        public string ErrandChangedTime { get; set; } = null!;
        public string ErrandStatus { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
