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
    
    public partial class Dep_TB
    {
        public Dep_TB()
        {
            this.User_TB = new HashSet<User_TB>();
        }
    
        public int ID { get; set; }
        public string Dep_Name { get; set; }
        public string Role_Dep_Name { get; set; }
    
        public virtual ICollection<User_TB> User_TB { get; set; }
    }
}
