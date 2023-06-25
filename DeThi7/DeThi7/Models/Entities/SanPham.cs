namespace DeThi7.Models.Entities
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
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Mô tả ngắn phải bắt đầu bằng một chữ cái")]
        public string TenSanPham { get; set; }

        public int? MaPhanLoai { get; set; }

        [StringLength(100)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chỉ được nhập số ")]
        public string GiaNhap { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chỉ được nhập số ")]
        public string DonGiaBanNhoNhat { get; set; }

        [StringLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Chỉ được nhập số ")]
        public string DonGiaBanLonNhat { get; set; }

        [Column(TypeName = "ntext")]
        public string TrangThai { get; set; }

        [Column(TypeName = "ntext")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9\s]*$", ErrorMessage = "Mô tả ngắn phải bắt đầu bằng một chữ cái")]
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
