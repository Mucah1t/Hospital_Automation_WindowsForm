//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hospital_ProjectEntities1 : DbContext
    {
        public Hospital_ProjectEntities1()
            : base("name=Hospital_ProjectEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Announcement> Tbl_Announcement { get; set; }
        public virtual DbSet<Tbl_Appoinment> Tbl_Appoinment { get; set; }
        public virtual DbSet<Tbl_Branch> Tbl_Branch { get; set; }
        public virtual DbSet<Tbl_Doctor> Tbl_Doctor { get; set; }
        public virtual DbSet<Tbl_Patient> Tbl_Patient { get; set; }
        public virtual DbSet<Tbl_Secretary> Tbl_Secretary { get; set; }
    }
}
