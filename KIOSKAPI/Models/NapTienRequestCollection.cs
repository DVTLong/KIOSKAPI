using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KIOSKAPI.Models;
namespace KIOSKAPI.Models
{
    public class NapTienRequestCollection
    {
        public string Token { get; set; }
        public string MaKIOSK { get; set; }
        public string MaSSC { get; set; }
        public List<ChiTietNapTableType> ChiTietNapTableType { get; set; }
    }
}