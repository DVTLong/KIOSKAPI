//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KIOSKAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LanNap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LanNap()
        {
            this.ChiTietNaps = new HashSet<ChiTietNap>();
        }
    
        public int STT { get; set; }
        public System.DateTime NgayNap { get; set; }
        public System.TimeSpan GioNap { get; set; }
        public decimal TongSoTienNap { get; set; }
        public string MAKO { get; set; }
        public string MaSSC { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNap> ChiTietNaps { get; set; }
        public virtual KIOSK KIOSK { get; set; }
    }
}
