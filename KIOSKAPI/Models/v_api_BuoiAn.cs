using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_BuoiAn
    {
        public int MaBA { get; set; }
        public string TenBA { get; set; }
        public TimeSpan? GioBD { get; set; }
        public TimeSpan? GioKT { get; set; }
        public int? SoHD { get; set; }
    }
}