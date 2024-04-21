using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Phong_Tro.Models;

public partial class PhongTroContext : DbContext
{
    public PhongTroContext()
    {
    }

    public PhongTroContext(DbContextOptions<PhongTroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnhPhongTro> AnhPhongTros { get; set; }

    public virtual DbSet<BaiDang> BaiDangs { get; set; }

    public virtual DbSet<ChuTro> ChuTros { get; set; }

    public virtual DbSet<DanhGia> DanhGia { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }

    public virtual DbSet<LoaiTk> LoaiTks { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongTro> PhongTros { get; set; }

    public virtual DbSet<QuaTrinhDangBai> QuaTrinhDangBais { get; set; }

    public virtual DbSet<QuanLy> QuanLies { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

  /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=PhongTro;User ID=sa;Password=123456;TrustServerCertificate=true");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnhPhongTro>(entity =>
        {
            entity.HasKey(e => e.MaAnh).HasName("PK__AnhPhong__356240DFCB93209A");

            entity.ToTable("AnhPhongTro");

            entity.Property(e => e.MaAnh).ValueGeneratedNever();
            entity.Property(e => e.MaPhongTro).HasMaxLength(8);
            entity.Property(e => e.Urlanh)
                .HasMaxLength(255)
                .HasColumnName("URLAnh");

            entity.HasOne(d => d.MaPhongTroNavigation).WithMany(p => p.AnhPhongTros)
                .HasForeignKey(d => d.MaPhongTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AnhPhongT__MaPho__17036CC0");
        });

        modelBuilder.Entity<BaiDang>(entity =>
        {
            entity.HasKey(e => e.MaBaiDang).HasName("PK__BaiDang__BF5D50C51B18FD18");

            entity.ToTable("BaiDang");

            entity.Property(e => e.MaBaiDang).HasMaxLength(8);
            entity.Property(e => e.MaChuTro).HasMaxLength(8);
            entity.Property(e => e.MaPhongTro).HasMaxLength(8);
            entity.Property(e => e.NgayDang).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");

            entity.HasOne(d => d.MaChuTroNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.MaChuTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiDang__MaChuTr__0E6E26BF");

            entity.HasOne(d => d.MaPhongTroNavigation).WithMany(p => p.BaiDangs)
                .HasForeignKey(d => d.MaPhongTro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BaiDang__MaPhong__10566F31");
        });

        modelBuilder.Entity<ChuTro>(entity =>
        {
            entity.HasKey(e => e.MaChuTro).HasName("PK__ChuTro__D1B7162A01D6AFB4");

            entity.ToTable("ChuTro");

            entity.Property(e => e.MaChuTro).HasMaxLength(8);
            entity.Property(e => e.Cccd).HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.ChuTros)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChuTro__Email__01142BA1");
        });

        modelBuilder.Entity<DanhGia>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGia__AA9515BFEA9485BD");

            entity.Property(e => e.MaDanhGia).HasMaxLength(8);
            entity.Property(e => e.MaBaiDang).HasMaxLength(8);
            entity.Property(e => e.MaKhachHang).HasMaxLength(8);
            entity.Property(e => e.NgayDanhGia).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");

            entity.HasOne(d => d.MaBaiDangNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaBaiDang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DanhGia__MaBaiDa__14270015");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DanhGia__MaKhach__1332DBDC");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5A0D362A2");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(8);
            entity.Property(e => e.Cccd).HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KhachHang__Email__03F0984C");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoaiPhong).HasName("PK__LoaiPhon__23021217F1F99836");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.MaLoaiPhong).ValueGeneratedNever();
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<LoaiTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.LoaiTk).HasName("PK__LoaiTaiK__48258AD1F4D0A671");

            entity.ToTable("LoaiTaiKhoan");

            entity.Property(e => e.LoaiTk)
                .ValueGeneratedNever()
                .HasColumnName("LoaiTK");
            entity.Property(e => e.TenTk)
                .HasMaxLength(50)
                .HasColumnName("TenTK");
        });

        modelBuilder.Entity<LoaiTk>(entity =>
        {
            entity.HasKey(e => e.MaLoaiTk).HasName("PK__LoaiTK__1224F254A4E1CBE1");

            entity.ToTable("LoaiTK");

            entity.Property(e => e.MaLoaiTk)
                .ValueGeneratedNever()
                .HasColumnName("MaLoaiTK");
            entity.Property(e => e.TenLoaiTk)
                .HasMaxLength(30)
                .HasColumnName("TenLoaiTK");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA479D839B28");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(10);
            entity.Property(e => e.Cccd)
                .HasMaxLength(10)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(20);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__NhanVien__Email__489AC854");
        });

        modelBuilder.Entity<PhongTro>(entity =>
        {
            entity.HasKey(e => e.MaPhongTro).HasName("PK__PhongTro__CEEDF1E14FA5EB80");

            entity.ToTable("PhongTro");

            entity.Property(e => e.MaPhongTro).HasMaxLength(8);
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Phuong).HasMaxLength(30);
            entity.Property(e => e.Quan).HasMaxLength(30);
            entity.Property(e => e.SlnguoiToiDa).HasColumnName("SLNguoiToiDa");
            entity.Property(e => e.TienIch).HasColumnType("text");

            entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.PhongTros)
                .HasForeignKey(d => d.MaLoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhongTro__MaLoai__0B91BA14");
        });

        modelBuilder.Entity<QuaTrinhDangBai>(entity =>
        {
            entity.HasKey(e => e.MaQuaTrinhDangBai).HasName("PK__QuaTrinh__061EC20A535B13F6");

            entity.ToTable("QuaTrinhDangBai");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MaBaiDang).HasMaxLength(8);
            entity.Property(e => e.NgayThayDoi).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasColumnType("text");
            entity.Property(e => e.TrangThai).HasMaxLength(10);

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.QuaTrinhDangBais)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__QuaTrinhD__Email__4B7734FF");

            entity.HasOne(d => d.MaBaiDangNavigation).WithMany(p => p.QuaTrinhDangBais)
                .HasForeignKey(d => d.MaBaiDang)
                .HasConstraintName("FK__QuaTrinhD__MaBai__4C6B5938");
        });

        modelBuilder.Entity<QuanLy>(entity =>
        {
            entity.HasKey(e => e.MaQuanLy).HasName("PK__QuanLy__2AB9EAF8AFF8A547");

            entity.ToTable("QuanLy");

            entity.Property(e => e.MaQuanLy).HasMaxLength(8);
            entity.Property(e => e.Cccd).HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.QuanLies)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuanLy__Email__06CD04F7");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__TaiKhoan__A9D10535A09BD407");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LoaiTk).HasColumnName("LoaiTK");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.LoaiTkNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.LoaiTk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LoaiTaiKhoan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
