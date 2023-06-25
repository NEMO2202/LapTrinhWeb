namespace DeThi8.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTietSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        public int? SoLuongMua { get; set; }

        [StringLength(20)]
        public string DonGiaBan { get; set; }

        public virtual ChiTietSPBan ChiTietSPBan { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
