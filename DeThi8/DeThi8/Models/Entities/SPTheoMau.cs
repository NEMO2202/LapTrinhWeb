namespace DeThi8.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SPTheoMau")]
    public partial class SPTheoMau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SPTheoMau()
        {
            AnhChiTietSPs = new HashSet<AnhChiTietSP>();
            ChiTietSPBans = new HashSet<ChiTietSPBan>();
        }

        [Key]
        public int MaSPTheoMau { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaMau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhChiTietSP> AnhChiTietSPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSPBan> ChiTietSPBans { get; set; }

        public virtual MauSac MauSac { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
