//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project123.Components.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestDetails
    {
        public int DetailID { get; set; }
        public int RequestID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal AgreedPrice { get; set; }
    
        public virtual AgentRequests AgentRequests { get; set; }
        public virtual Products Products { get; set; }
    }
}
