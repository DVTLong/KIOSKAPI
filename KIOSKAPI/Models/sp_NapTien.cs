using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KIOSKAPI.Models
{
    [StoredProcedure("sp_NapTien")]
    public class sp_NapTien
    {
        [StoredProcedureParameter(SqlDbType.Date, ParameterName = "ngaynap")]
        public DateTime NgayNap { get; set; }

        [StoredProcedureParameter(SqlDbType.Time, ParameterName = "gionap")]
        public TimeSpan GioNap { get; set; }

        [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "massc")]
        public string MaSSC { get; set; }

        [StoredProcedureParameter(SqlDbType.VarChar, ParameterName = "mako")]
        public string MaKO { get; set; }

        [StoredProcedureParameter(SqlDbType.Udt, ParameterName = "ctn")]
        public List<ChiTietNapTableType> ChiTietNapTableType { get; set; }
    }
}