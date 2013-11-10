using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 {get;set;}
        public string AddressLine2 {get;set;}
        public string PostalCode {get;set;}
        public City City { get; set; }

    }
}
