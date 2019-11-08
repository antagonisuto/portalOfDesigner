using System;
using System.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Designers> Designers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        //public DbSet<Orders_Designers> Orders_Designers { get; set; }
        public DbSet<Requests> Requests { get; set; }
        //public DbSet<Requests_Customers> Requests_Customers { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----------------Request _ Customers ------------//
            modelBuilder.Entity<Requests_Customers>()
                .HasKey(t => new { t.Customers_id, t.Request_id });

            modelBuilder.Entity<Requests_Customers>()
                .HasOne(sc => sc.Request)
                .WithMany(s => s.Requests_Customers)
                .HasForeignKey(sc => sc.Request_id);

            modelBuilder.Entity<Requests_Customers>()
                .HasOne(sc => sc.Customer)
                .WithMany(c => c.Requests_Customers)
                .HasForeignKey(sc => sc.Customers_id);
            //----------------Request _ Customers ------------//

            //----------------Orders _ Designer ------------//
            modelBuilder.Entity<Orders_Designers>()
                 .HasKey(t => new { t.Designer_id, t.Order_id });

            modelBuilder.Entity<Orders_Designers>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Orders_Designers)
                .HasForeignKey(sc => sc.Order_id);

            modelBuilder.Entity<Orders_Designers>()
                .HasOne(sc => sc.Designer)
                .WithMany(c => c.Orders_Designers)
                .HasForeignKey(sc => sc.Designer_id);
            //----------------Orders _ Designer------------//
        }
    }
    
}
