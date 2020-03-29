using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lab11_5_From_Database_To_HTML
{
    class SakilaContext :DbContext
    {
        public DbSet<film> Film { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost\sqlexpress;Database=sakila;Trusted_Connection=True;")
;
        }
    }
}

