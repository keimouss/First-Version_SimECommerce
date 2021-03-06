﻿using System;
using System.Collections.Generic;

namespace SimECommerce.Models
{
    public partial class CustomerAddresses
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
