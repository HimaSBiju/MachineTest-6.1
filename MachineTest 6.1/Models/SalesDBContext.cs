using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MachineTest_6._1.Models
{
    public partial class SalesDBContext : DbContext
    {
        public SalesDBContext()
        {
        }

        public SalesDBContext(DbContextOptions<SalesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SJS-ZENBOOK\\SQLEXPRESS; Initial Catalog=SalesDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRegistration>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Customer__213EE774603C0BD5");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.CustomerRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__CustomerRe__l_id__267ABA7A");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F8D4A56B51");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__Purchase__904BC20EDD358903");

                entity.Property(e => e.OId).HasColumnName("o_id");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("deliveryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("itemName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseOrderNumber).HasColumnName("purchaseOrderNumber");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VId).HasColumnName("v_id");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__PurchaseOr__c_id__2B3F6F97");

                entity.HasOne(d => d.V)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.VId)
                    .HasConstraintName("FK__PurchaseOr__v_id__2C3393D0");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VId)
                    .HasName("PK__Vendor__AD3D8441CD68942F");

                entity.Property(e => e.VId).HasColumnName("v_id");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendorName")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
