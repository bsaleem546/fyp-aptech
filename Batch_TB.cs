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
    
    public partial class Batch_TB
    {
        public Batch_TB()
        {
            this.Lab_Time_TB = new HashSet<Lab_Time_TB>();
            this.Sudent_TB = new HashSet<Sudent_TB>();
        }
    
        public int ID { get; set; }
        public string BATCH_CODE { get; set; }
        public string BATCH_SESSION { get; set; }
        public Nullable<int> USERS_ID { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<bool> STATUS { get; set; }
    
        public virtual User_TB User_TB { get; set; }
        public virtual ICollection<Lab_Time_TB> Lab_Time_TB { get; set; }
        public virtual ICollection<Sudent_TB> Sudent_TB { get; set; }
    }
}
