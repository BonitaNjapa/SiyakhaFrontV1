﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ShoppingCartM
{
    public class Category
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        [Index("Category_Index", IsUnique = true)]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int Department_ID { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
