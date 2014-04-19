﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookMgnt.Models
{
    public class BookContext:DbContext
    {
        public BookContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}