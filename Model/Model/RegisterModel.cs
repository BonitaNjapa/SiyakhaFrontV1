using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 10), Required(ErrorMessage = "Required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }

    
}
