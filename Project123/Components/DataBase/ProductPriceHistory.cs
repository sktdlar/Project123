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
    
    public partial class ProductPriceHistory
    {
        public int HistoryID { get; set; }
        public int ProductID { get; set; }
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public System.DateTime ChangeDate { get; set; }
    
        public virtual Products Products { get; set; }
    }
}
