//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace PropertiesApi.Domain.Entities;

//public partial class RealEstateDbContext : DbContext
//{
//    public RealEstateDbContext()
//    {
//    }

//    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<OwnerProperty> OwnerProperties { get; set; }

//    public virtual DbSet<Property> Properties { get; set; }

//    public virtual DbSet<PropertyImage> PropertyImages { get; set; }

//    public virtual DbSet<PropertyTrace> PropertyTraces { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-QJ2SAIJM\\SQLEXPRESS;Database=RealEstateDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<OwnerProperty>(entity =>
//        {
//            entity.HasKey(e => e.IdOwner).HasName("PK__OwnerPro__D3261816C9F839F9");

//            entity.ToTable("OwnerProperty");

//            entity.Property(e => e.Address)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.FullName)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Photo)
//                .HasMaxLength(100)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Property>(entity =>
//        {
//            entity.HasKey(e => e.IdProperty).HasName("PK__Property__842B6AA726B4BEE3");

//            entity.ToTable("Property");

//            entity.Property(e => e.Address)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.CodeInternal)
//                .HasMaxLength(30)
//                .IsUnicode(false);
//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

//            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Properties)
//                .HasForeignKey(d => d.IdOwner)
//                .HasConstraintName("FK__Property__IdOwne__59063A47");
//        });

//        modelBuilder.Entity<PropertyImage>(entity =>
//        {
//            entity.HasKey(e => e.IdPropertyImage).HasName("PK__Property__018BACD592431DE6");

//            entity.ToTable("PropertyImage");

//            entity.Property(e => e.FileUrl).HasMaxLength(255);
//        });

//        modelBuilder.Entity<PropertyTrace>(entity =>
//        {
//            entity.HasKey(e => e.IdPropertyTrace).HasName("PK__Property__373407C9CCE58C77");

//            entity.ToTable("PropertyTrace");

//            entity.Property(e => e.Name)
//                .HasMaxLength(50)
//                .IsUnicode(false);
//            entity.Property(e => e.Tax).HasColumnType("decimal(15, 2)");
//            entity.Property(e => e.Value).HasColumnType("decimal(15, 2)");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
