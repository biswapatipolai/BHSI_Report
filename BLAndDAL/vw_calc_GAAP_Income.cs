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
    
    public partial class vw_calc_GAAP_Income
    {
        public string RegionLabel { get; set; }
        public Nullable<short> RegionSort { get; set; }
        public string continent { get; set; }
        public string ProductLabel { get; set; }
        public Nullable<short> ProductSort { get; set; }
        public Nullable<System.DateTime> Qtr { get; set; }
        public int MeasureSort { get; set; }
        public string Measure { get; set; }
        public int Mgt { get; set; }
        public int FullDac { get; set; }
        public int Active { get; set; }
        public Nullable<decimal> ActualAmt { get; set; }
        public int BudgetAmt { get; set; }
    }
}
