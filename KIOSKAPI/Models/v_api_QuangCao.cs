using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_QuangCao
    {
        public int SoHD { get; set; }
        public string MAKO { get; set; }
        public int MaQC { get; set; }
        public System.DateTime NgayBDQC { get; set; }
        public System.DateTime NgayKTQC { get; set; }
        public string NoiDung { get; set; }
        public byte[] ImageQC { get; set; }
        public int ThoiLuong { get; set; }
    }
}