using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class ProductAttribute
    {
        public int ProductAttributeID { get; set; }

        public int ProductID { get; set; }

        public bool Enabled { get; set; }

        public virtual List<ProductAttributeTranslation> ProductAttributeTranslations { get; set; }

        public virtual List<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
