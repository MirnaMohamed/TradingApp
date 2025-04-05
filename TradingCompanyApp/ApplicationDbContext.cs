using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using TradingCompanyApp.Models;

namespace TradingCompanyApp
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<ItemRequest> ItemsRequests { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WarehouseItem> WarehouseItem { get; set; }

        public DbSet<SupplyRequest> SupplyRequests { get; set; }

        public DbSet<ReleaseRequest> ReleaseRequests { get; set; }
        public DbSet<TransferRequest> TransferRequests { get; set; }
        public static User ActiveUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Transfer Request relationship
            EntityTypeBuilder<TransferRequest> transferRequests = modelBuilder.Entity<TransferRequest>();
            transferRequests.HasOne(tr => tr.SourceWarehouse)
                .WithMany(w => w.OutgoingTransferRequests)
                .HasForeignKey(tr => tr.SourceWarehouseName)
                .HasPrincipalKey(w => w.Name)
                .OnDelete(DeleteBehavior.Restrict);
            transferRequests.HasOne(tr => tr.DestinationWarehouse).WithMany(w => w.IncomingTransferRequests)
                .HasForeignKey(tr => tr.DestinationWarehouseName)
                .HasPrincipalKey(w => w.Name)
                .OnDelete(DeleteBehavior.Restrict);
            transferRequests.Property(t => t.RequestDate)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TransferredItem>().HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => new { si.WarehouseId, si.ItemCode })
                .OnDelete(DeleteBehavior.Restrict);

            //Supply request relationship
            EntityTypeBuilder<SupplyRequest> supplyRequests = modelBuilder.Entity<SupplyRequest>();
            supplyRequests.HasOne(sr => sr.Warehouse)
                .WithMany(w => w.SupplyRequests)
                .HasForeignKey(sr => sr.WarehouseName)
                .HasPrincipalKey(w => w.Name)
                .OnDelete(DeleteBehavior.Restrict);
            supplyRequests.Property(sr => sr.RequestDate)
                .HasDefaultValueSql("GETDATE()");

            //Supply request item relationship
            EntityTypeBuilder<SupplyRequestItem> supplyItems = modelBuilder.Entity<SupplyRequestItem>();
            supplyItems.HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => new { si.WarehouseId, si.ItemCode })
                .OnDelete(DeleteBehavior.Cascade);

            //Release request relationship
            EntityTypeBuilder<ReleaseRequest> releaseRequests = modelBuilder.Entity<ReleaseRequest>();
            releaseRequests.HasOne(sr => sr.Warehouse)
                .WithMany(w => w.ReleaseRequests)
                .HasForeignKey(sr => sr.WarehouseName)
                .HasPrincipalKey(w => w.Name)
                .OnDelete(DeleteBehavior.Restrict);
            releaseRequests.Property(sr => sr.RequestDate)
                .HasDefaultValueSql("GETDATE()");
            EntityTypeBuilder<ReleaseRequestItem> releaseItems = modelBuilder.Entity<ReleaseRequestItem>();
            releaseItems.HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => new { si.WarehouseId, si.ItemCode })
                .OnDelete(DeleteBehavior.Cascade);

            //Composite keys
            modelBuilder.Entity<WarehouseItem>()
                .HasKey(wi => new { wi.WarehouseId, wi.ItemCode });
            modelBuilder.Entity<SupplyRequestItem>()
                .HasKey(wi => new { wi.RequestId, wi.ItemCode });
            modelBuilder.Entity<ReleaseRequestItem>()
                .HasKey(wi => new { wi.RequestId, wi.ItemCode });
            modelBuilder.Entity<TransferredItem>()
                .HasKey(wi => new { wi.RequestId, wi.ItemCode });
            modelBuilder.Entity<User>()
                .HasMany(u => u.AccessibleWarehouses)
                .WithMany(w => w.AuthorizedUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "WarehouseUsers", //join table name
                    j => j
                    .HasOne<Warehouse>().WithMany()
                    .HasForeignKey("WarehouseId")
                    .OnDelete(DeleteBehavior.Restrict),

                    j => j
                    .HasOne<User>().WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Restrict) 
                );
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            //making each child entity a separate table
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Customer>().Property(c => c.MobileNumber).IsRequired(false);
            modelBuilder.Entity<Customer>().Property(c => c.Website).IsRequired(false);
            modelBuilder.Entity<Supplier>().Property(c => c.MobileNumber).IsRequired(false);

            //modelBuilder.Entity<SupplyRequest>().ToTable("SupplyRequests");
            //modelBuilder.Entity<ReleaseRequest>().ToTable("ReleaseRequests");
            //modelBuilder.Entity<TransferRequest>().ToTable("TransferRequests");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=.;Initial Catalog=TradingDb;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
