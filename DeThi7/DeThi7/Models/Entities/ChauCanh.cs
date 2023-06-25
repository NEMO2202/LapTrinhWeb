using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DeThi7.Models.Entities
{
    public partial class ChauCanh : DbContext
    {
        public ChauCanh()
            : base("name=ChauCanh")
        {
        }

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
