﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class e_AdminstratorEntities : DbContext
    {
        public e_AdminstratorEntities()
            : base("name=e_AdminstratorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin_TB> Admin_TB { get; set; }
        public DbSet<Batch_TB> Batch_TB { get; set; }
        public DbSet<Complaint_TB> Complaint_TB { get; set; }
        public DbSet<Dep_TB> Dep_TB { get; set; }
        public DbSet<Lab_TB> Lab_TB { get; set; }
        public DbSet<Lab_Time_TB> Lab_Time_TB { get; set; }
        public DbSet<Sudent_TB> Sudent_TB { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User_TB> User_TB { get; set; }
    }
}
