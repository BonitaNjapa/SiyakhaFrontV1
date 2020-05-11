using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address
    {

        public string StreetNumber { get; set; }
        public string street_name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        //string streetName = formCollection["street_number"];
        //Session["street_name"] =formCollection["street_name"];
        //    Session["City"] = formCollection["City"];
        //    Session["State"] = formCollection["State"];
        //    Session["ZipCode"] = formCollection["ZipCode"];
        //    Session["Country"] = formCollection["Country"];
    }
}
