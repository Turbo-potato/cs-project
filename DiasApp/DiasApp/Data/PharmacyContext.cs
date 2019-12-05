using DiasApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Data
{
    public class PharmacyContext : IdentityDbContext<User>//DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //MANY-TO-MANY
            modelBuilder.Entity<DrugManufacturer>().HasKey(dm => new { dm.DrugId, dm.ManufacturerId });

            modelBuilder.Entity<DrugManufacturer>()
                .HasOne(dm => dm.Drug)
                .WithMany(d => d.DrugManufacturers)
                .HasForeignKey(dm => dm.DrugId);

            modelBuilder.Entity<DrugManufacturer>()
                .HasOne(dm => dm.Manufacturer)
                .WithMany(m => m.DrugManufacturers)
                .HasForeignKey(dm => dm.ManufacturerId);

            //ONE-TO-MANY
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Patients);

            //ONE-TO-ONE
            modelBuilder.Entity<Doctor>()
                .HasOne(o => o.Organization)
                .WithOne(d => d.Doctor)
                .HasForeignKey<Organization>(d => d.DoctorForeignKey);
        }

        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Drug> Drug { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<DiasApp.Models.Doctor> Doctor { get; set; }
        public DbSet<DiasApp.Models.Organization> Organization { get; set; }
        public DbSet<DiasApp.Models.Patient> Patient { get; set; }
        public DbSet<DiasApp.Models.Order> Order { get; set; }
        public DbSet<DiasApp.Models.Prescription> Prescription { get; set; }
    }
}
