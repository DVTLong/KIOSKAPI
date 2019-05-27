using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_LoaiMatHang
    {
        public int MaLMH { get; set; }
        public string TenLMH { get; set; }
        public byte[] ImageLMH { get; set; }
        public int? SoHD { get; set; }
    }
}