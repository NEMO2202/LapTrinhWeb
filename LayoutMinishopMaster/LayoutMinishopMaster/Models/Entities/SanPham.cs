namespace LayoutMinishopMaster.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            SPTheoMaus = new HashSet<SPTheoMau>();
        }

        [Key]
        public int MaSanPham { get; set; }

        [StringLength(20)]
        public string TenSanPham { get; set; }

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        public string GiaNhap { get; set; }

        [StringLength(10)]
        public string DonGiaBanNhoNhat { get; set; }

        [StringLength(10)]
        public string DonGiaBanLonNhat { get; set; }

        [Column(TypeName = "ntext")]
        public string TrangThai { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTaNgan { get; set; }

        [StringLength(100)]
        public string AnhDaiDien { get; set; }

        [StringLength(200)]
        public string NoiBat { get; set; }

        public int? MaPhanLoaiPhu { get; set; }

        public virtual PhanLoai PhanLoai { get; set; }

        public virtual PhanLoaiPhu PhanLoaiPhu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SPTheoMau> SPTheoMaus { get; set; }
    }
}
