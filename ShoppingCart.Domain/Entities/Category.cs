using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    [Table("Category")]
    public class Category 
    {
        public int CategoryID { get; set; }

        public virtual List<CategoryTranslation> CategoryTranslations { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public virtual Category Parent { get; set; }
        
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<CategoryNode> Ancestors { get; set; }
        public virtual ICollection<CategoryNode> Offspring { get; set; }
    }


    public class CategoryNode 
    {
        public int AncestorId { get; set; }
        public virtual Category Ancestor { get; set; }

        public int OffspringId { get; set; }
        public virtual Category Offspring { get; set; }

        public int Separation { get; set; }
    }

}
