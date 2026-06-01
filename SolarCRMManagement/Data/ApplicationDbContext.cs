using Microsoft.EntityFrameworkCore;
using SolarCRMManagement.Models.Master;
using SolarCRMManagement.Models.Procurement;

namespace SolarCRMManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Master Tables

        public DbSet<State> States { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<ItemMaster> ItemMasters { get; set; }

        #endregion

        #region Procurement

        public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }

        public DbSet<PurchaseRequisitionItem> PurchaseRequisitionItems { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // City -> Branch
            modelBuilder.Entity<Branch>()
                .HasOne(b => b.City)
                .WithMany(c => c.Branches)
                .HasForeignKey(b => b.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Branch -> Warehouse
            modelBuilder.Entity<Warehouse>()
                .HasOne(w => w.Branch)
                .WithMany(b => b.Warehouses)
                .HasForeignKey(w => w.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee -> Branch
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee -> Warehouse
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Warehouse)
                .WithMany()
                .HasForeignKey(e => e.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase Order -> Vendor
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Vendor)
                .WithMany()
                .HasForeignKey(p => p.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase Order -> Warehouse
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Warehouse)
                .WithMany()
                .HasForeignKey(p => p.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase Requisition -> Warehouse
            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(p => p.Warehouse)
                .WithMany()
                .HasForeignKey(p => p.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchase Requisition -> Branch
            modelBuilder.Entity<PurchaseRequisition>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}