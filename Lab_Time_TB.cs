//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_PROJECT_e_Adminstrator
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lab_Time_TB
    {
        public int ID { get; set; }
        public Nullable<int> Batch_ID { get; set; }
        public Nullable<int> Lab_ID { get; set; }
        public string Lab_Timming { get; set; }
        public string Lab_Days { get; set; }
    
        public virtual Batch_TB Batch_TB { get; set; }
        public virtual Lab_TB Lab_TB { get; set; }
    }
}
