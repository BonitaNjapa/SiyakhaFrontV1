using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CompSuppManager
{
  public class Branch
    {
        [Key]
        public int Id { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual BranchAddress BranchAddress { get; set; }
    }
    public class BranchAddress
    {
        [ForeignKey("Branch")]
        public int BranchAddressId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
