using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_MatHang
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int? SoLuongTon { get; set; }
        public decimal? DonGia { get; set; }
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public bool TrangThai { get; set; }
        public byte[] ImageMH { get; set; }
        public int MaLMH { get; set; }
        public string TenLMH { get; set; }
        public int? SoHD { get; set; }
    }
}