using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BukyWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BukyWebRazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DispayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DispayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DispayOrder = 3 }
            );
        }
    }
}