namespace DeThi8.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnhChiTietSP")]
    public partial class AnhChiTietSP
    {
        [Key]
        public int MaAnh { get; set; }

        public int? MaSPTheoMau { get; set; }

        [StringLength(100)]
        public string TenFileAnh { get; set; }

        public virtual SPTheoMau SPTheoMau { get; set; }
    }
}
