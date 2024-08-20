using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PostuPortalas.Core.Models;

namespace PostuPortalas.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=posts;Trusted_Connection=true;TrustServerCertificate=True");
        }
    }
}
