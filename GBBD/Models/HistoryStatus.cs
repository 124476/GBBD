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
    
    public partial class HistoryStatus
    {
        public int Id { get; set; }
        public Nullable<int> YdId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string Comment { get; set; }
    
        public virtual VYStatus VYStatus { get; set; }
        public virtual Ydovstvorenie Ydovstvorenie { get; set; }
    }
}