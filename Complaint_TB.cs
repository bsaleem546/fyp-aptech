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
    
    public partial class Complaint_TB
    {
        public int ID { get; set; }
        public string ComplainName { get; set; }
        public string Decription { get; set; }
        public Nullable<int> Days_Of_Fix { get; set; }
        public Nullable<int> Users_ID { get; set; }
        public Nullable<System.DateTime> Date_Of_Complaint { get; set; }
        public Nullable<int> MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public string STATUS { get; set; }
    
        public virtual User_TB User_TB { get; set; }
    }
}
