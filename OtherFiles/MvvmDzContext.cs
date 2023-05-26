using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mvvm.Models;

namespace mvvm.OtherFiles;

public partial class MvvmDzContext : DbContext
{
    public MvvmDzContext()
    {
    }

    public MvvmDzContext(DbContextOptions<MvvmDzContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcategory> Tblcategories { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    public virtual DbSet<Tblprovider> Tblproviders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("host=localhost;userid=root;password=Myl1ttledvmk3003@;database=\"mvvm dz\"", ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Tblcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblcategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category).HasMaxLength(255);
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblproduct");

            entity.HasIndex(e => e.Category, "FK_tbl_product_tbl_category_id");

            entity.HasIndex(e => e.ProviderId, "FK_tbl_product_tbl_manufacturer_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("FK_tbl_product_tbl_category_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK_tbl_product_tbl_manufacturer_id");
        });

        modelBuilder.Entity<Tblprovider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tblprovider");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Provider).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
