using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class CategoryImage
    {
        public int CategoryImageID { get; set; }

        public int CategoryID { get; set; }

        public string CategoryImagePath { get; set; }

        public short DisplayOrder { get; set; }

        public virtual Category Category { get; set; }
    }
}
