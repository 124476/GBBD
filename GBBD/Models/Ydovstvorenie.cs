//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GBBD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ydovstvorenie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ydovstvorenie()
        {
            this.HistoryStatus = new HashSet<HistoryStatus>();
        }
    
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> LicenceDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string Categories { get; set; }
        public string LicenceSeries { get; set; }
        public string LicenceNumber { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryStatus> HistoryStatus { get; set; }
        public virtual User User { get; set; }
        public virtual VYStatus VYStatus { get; set; }
    }
}