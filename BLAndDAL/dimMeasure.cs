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
    
    public partial class dimMeasure
    {
        public int RowID { get; set; }
        public Nullable<short> MeasureId { get; set; }
        public string OrignalMeasure { get; set; }
        public string Measure { get; set; }
        public Nullable<bool> Mgt { get; set; }
        public Nullable<bool> FullDac { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> SortOrder { get; set; }
        public Nullable<bool> Expense { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string SrcMeasureAlias { get; set; }
    }
}
