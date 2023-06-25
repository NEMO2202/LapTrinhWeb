namespace DeThi8.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSPBan")]
    public partial class ChiTietSPBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietSPBan()
        {
            ChiTietHDs = new HashSet<ChiTietHD>();
        }

        [Key]
        public int MaChiTietSP { get; set; }

        public int? MaSPTheoMau { get; set; }

        [StringLength(10)]
        public string KichCo { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(20)]
        public string DonGiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual SPTheoMau SPTheoMau { get; set; }
    }
}
