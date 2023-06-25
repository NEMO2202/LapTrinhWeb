using LayoutMinishopMaster.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayoutMinishopMaster.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<PhanLoai> PhanLoais { get; set; }
        public IEnumerable<SanPham> SanPhams { get; set; }
    }
}