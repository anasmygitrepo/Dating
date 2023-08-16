using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Date.Models;
using Microsoft.EntityFrameworkCore;

namespace Date.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }


        public DbSet<AppUser> Users{get;set;}
    }
}