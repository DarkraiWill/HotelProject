//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP2
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceOrder
    {
        public int ServiceOrderID { get; set; }
        public int BookingID { get; set; }
        public int ServiceID { get; set; }
        public System.DateTime OrderDate { get; set; }
    
        public virtual Booking Booking { get; set; }
        public virtual Service Service { get; set; }
    }
}
