﻿using Microsoft.EntityFrameworkCore;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); 
        }
        public DbSet<BulkyWebRazor_Temp.Models.Category> Category { get; set; } = default!;
    }
}
