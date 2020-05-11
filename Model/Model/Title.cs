using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Title
    {
        [Display(Name = "Title")]
        public int TitleId { get; set; }
        [Display(Name = "Title")]
        public string TitleName { get; set; }

    }
}
