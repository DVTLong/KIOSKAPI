using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_DotKhuyenMai
    {
        public int MaKM { get; set; }
        public System.DateTime NgayTao { get; set; }
        public System.DateTime NgayBD { get; set; }
        public System.DateTime NgayKT { get; set; }
        public int SoHD { get; set; }
    }
}