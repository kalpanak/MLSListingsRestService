using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLSListingsRestService.Models
{
    public class HomeDetails
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}