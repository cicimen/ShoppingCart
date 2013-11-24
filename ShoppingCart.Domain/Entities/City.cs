using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    [Table("City")]
    public class City
    {
        public int CityID { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
