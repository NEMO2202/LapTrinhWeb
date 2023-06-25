namespace DeThi8.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        public int MaDonHang { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public int? MaNguoiDung { get; set; }

        [StringLength(100)]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(100)]
        public string PTThanhToan { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }

        [StringLength(20)]
        public string TenNguoiNhanHang { get; set; }

        [StringLength(10)]
        public string SoDienThoaiNhanHang { get; set; }

        public double? TongTien { get; set; }

        [StringLength(100)]
        public string GiamGia { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
