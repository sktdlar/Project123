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
    
    public partial class MaterialStockHistory
    {
        public int HistoryID { get; set; }
        public int MaterialID { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public string ChangeType { get; set; }
        public decimal QuantityChange { get; set; }
    
        public virtual Materials Materials { get; set; }
    }
}
