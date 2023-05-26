using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvvm.Models;

namespace mvvm.OtherFiles;

public partial class MvvmDzContext : DbContext
{
    public MvvmDzContext()
    {
        Database.EnsureCreated();
    }

    public MvvmDzContext(DbContextOptions<MvvmDzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProvider> TblProviders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("host=192.168.200.13;user=student;password=student;database=\"mvvm dz\"", ServerVersion.Parse("10.3.38-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_category");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(255);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_product");

            entity.HasIndex(e => e.Category, "FK_tbl_product_tbl_category_id");

            entity.HasIndex(e => e.ProviderId, "FK_tbl_product_tbl_manufacturer_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category).HasColumnType("int(11)");
            entity.Property(e => e.CostOfOne).HasColumnType("int(11)");
            entity.Property(e => e.Discount).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProviderId).HasColumnType("int(11)");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_tbl_product_tbl_category_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK_tbl_product_tbl_manufacturer_id");
        });

        modelBuilder.Entity<TblProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tbl_provider");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Provider).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
