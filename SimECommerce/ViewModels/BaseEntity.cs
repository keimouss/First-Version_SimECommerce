using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ViewModels
{
    public abstract class BaseEntity
    {
        protected int id;
        public int Id => this.id;

    }
}
