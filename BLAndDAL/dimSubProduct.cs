//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLAndDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class dimSubProduct
    {
        public int RowID { get; set; }
        public Nullable<short> SubProductId { get; set; }
        public string SubProductName { get; set; }
        public string SubProductLabel { get; set; }
        public string SrcSubProductAlias { get; set; }
        public Nullable<short> ProductId { get; set; }
        public Nullable<short> SortOrder { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
    }
}
