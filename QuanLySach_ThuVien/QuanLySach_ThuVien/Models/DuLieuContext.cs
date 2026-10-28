using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLySach_ThuVien.Models;

public partial class DuLieuContext : DbContext
{
    public DuLieuContext()
    {
    }

    public DuLieuContext(DbContextOptions<DuLieuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CongViec> CongViecs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DuLieu;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CongViec>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PK__CongViec__B235742DE70B044C");

            entity.ToTable("CongViec");

            entity.Property(e => e.MaSach).HasMaxLength(15);
            entity.Property(e => e.GiaTien).HasMaxLength(12);
            entity.Property(e => e.TenSach).HasColumnType("ntext");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
