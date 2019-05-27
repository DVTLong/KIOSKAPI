using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    public class v_api_HinhThucThanhToan
    {
        public int MaHTTT { get; set; }
        public string TenHTTT { get; set; }
        public byte[] ImageHTTT { get; set; }
        public bool IsDeleted { get; set; }
    }
}