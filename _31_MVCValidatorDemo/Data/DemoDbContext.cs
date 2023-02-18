using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _31_MVCValidatorDemo.Models;

namespace _31_MVCValidatorDemo.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext (DbContextOptions<DemoDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<_31_MVCValidatorDemo.Models.UserViewModel> UserViewModel { get; set; }
    }
}
