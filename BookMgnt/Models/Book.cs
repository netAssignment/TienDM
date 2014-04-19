using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMgnt.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public int? CategoriesID { get; set; }
        public virtual Category Categories { get; set; }
        [Required]
        public string Author { get; set; }
        public string Introduce { get; set; }
        public string imagePath { get; set; }
        [Required]
        public DateTime pubYear { get; set; }
    }
}