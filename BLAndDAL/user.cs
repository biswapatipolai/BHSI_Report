//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int USER_ID { get; set; }
        public string EMAIL_ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string PASSWORD { get; set; }
        public short GROUP_ID { get; set; }
        public string USER_STATUS { get; set; }
        public System.DateTime CREATED_ON { get; set; }
        public Nullable<System.DateTime> MODIFIED_ON { get; set; }
        public short CREATED_BY_ID { get; set; }
        public short MODIFIED_BY_ID { get; set; }
        public Nullable<int> uid { get; set; }
    }
}
