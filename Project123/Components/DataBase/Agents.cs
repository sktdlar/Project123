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
    
    public partial class Agents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agents()
        {
            this.AgentPriorityHistory = new HashSet<AgentPriorityHistory>();
            this.AgentRequests = new HashSet<AgentRequests>();
            this.SalesPoints = new HashSet<SalesPoints>();
            this.AgentSalesHistory = new HashSet<AgentSalesHistory>();
        }
    
        public int AgentID { get; set; }
        public string Name { get; set; }
        public int AgentType_id { get; set; }
        public string LegalAddress { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string DirectorName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public byte[] Logo { get; set; }
        public int PriorityLevel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentPriorityHistory> AgentPriorityHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentRequests> AgentRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesPoints> SalesPoints { get; set; }
        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgentSalesHistory> AgentSalesHistory { get; set; }
    }
}
