using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DeThi1.Models
{
    public partial class BanQuanAo : DbContext
    {
        public BanQuanAo()
            : base("name=BanQuanAo")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AnhChiTietSP> AnhChiTietSPs { get; set; }
        public virtual DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public virtual DbSet<ChiTietSPBan> ChiTietSPBans { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<MauSac> MauSacs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanLoai> PhanLoais { get; set; }
        public virtual DbSet<PhanLoaiPhu> PhanLoaiPhus { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SPTheoMau> SPTheoMaus { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietSPBan>()
                .HasMany(e => e.ChiTietHDs)
                .WithRequired(e => e.ChiTietSPBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietHDs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);
        }
    }
}
