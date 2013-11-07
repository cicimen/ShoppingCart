using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class ProductAttributeValue
    {
        public int ProductAttributeValueID { get; set; }

        public int ProductAttributeID { get; set; }

        public bool Enabled { get; set; }

        public virtual List<ProductAttributeValueTranslation> ProductAttributeValueTranslations { get; set; }
    }
}
