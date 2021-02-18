﻿using System;
using Microsoft.EntityFrameworkCore;

namespace Assignment5.Models
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext (DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
