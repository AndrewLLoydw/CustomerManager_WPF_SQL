using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CustomerManager_WPF_SQL.Models;

namespace CustomerManager_WPF_SQL.Data
{
    public partial class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerErrand> CustomerErrands { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\addel\\source\\repos\\CustomerManager_WPF_SQL\\Data\\efw_customermanager_database.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StreetName).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38987BF7F6")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Customer__A9D105344B1E65F8")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Addre__3C69FB99");

                entity.HasOne(d => d.Errand)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.ErrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Erran__3D5E1FD2");
            });

            modelBuilder.Entity<CustomerErrand>(entity =>
            {
                entity.Property(e => e.ErrandChangedTime).HasMaxLength(20);

                entity.Property(e => e.ErrandCreatedTime).HasMaxLength(20);

                entity.Property(e => e.ErrandDescription).HasMaxLength(100);

                entity.Property(e => e.ErrandStatus).HasMaxLength(20);

                entity.Property(e => e.ErrandTitle).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
