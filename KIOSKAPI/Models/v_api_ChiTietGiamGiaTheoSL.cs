using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_ChiTietGiamGiaTheoSL
    {
        public int STT { get; set; }
        public int MaKM { get; set; }
        public int MaMH { get; set; }
        public decimal? DonGia { get; set; }
        public bool TrangThai { get; set; }
        public int SLMuaToiThieu { get; set; }
        public decimal Giam { get; set; }
    }
}