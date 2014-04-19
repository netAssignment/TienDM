using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMgnt.Models
{
    public class Category
    {
        public Category()
        {
            listBooks = new HashSet<Book>();
        }        
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Book> listBooks { get; set; }
    }
}