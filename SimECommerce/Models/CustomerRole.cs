using System;
using System.Collections.Generic;

namespace SimECommerce.Models
{
    public partial class CustomerRole
    {
        public CustomerRole()
        {
            CustomerCustomerRoleMapping = new HashSet<CustomerCustomerRoleMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool FreeShipping { get; set; }
        public bool TaxExempt { get; set; }
        public bool Active { get; set; }
        public bool IsSystemRole { get; set; }
        public string SystemName { get; set; }
        public int PurchasedWithProductId { get; set; }

        public virtual ICollection<CustomerCustomerRoleMapping> CustomerCustomerRoleMapping { get; set; }
    }
}
