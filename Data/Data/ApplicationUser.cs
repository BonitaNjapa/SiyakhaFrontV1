using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationUser : IdentityUser
    {
        public int TitleId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool isActive { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public string IDno { get; set; }
        public string DoB { get; set; }
        public string gender { get; set; }
    }
}
