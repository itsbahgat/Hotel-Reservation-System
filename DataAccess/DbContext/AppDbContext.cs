using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using System.Configuration;


namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .ToTable("Logins");   
            
            modelBuilder.Entity<Reservation>()
                .ToTable("Reservations");   
            
        }

    }
}
