using System;
using System.Collections.Generic;
using System.Text;

namespace SimECommerce.Entities
{
    public abstract class BaseStringEntity
    {
        string id;
        public string Id => this.id;
    }
}
