//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikMvcAppWithCRUD.Data.Northwind
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NorthwindEntities : DbContext
    {
        public NorthwindEntities()
            : base("name=NorthwindEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AdvisoryNote> AdvisoryNotes { get; set; }
        public DbSet<AdvisorySociety> AdvisorySocieties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Student_Misc> Student_Misc { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<vw_Matri_Grad_Dates> vw_Matri_Grad_Dates { get; set; }
        public DbSet<v_studentsAll> v_studentsAll { get; set; }
        public DbSet<v_StudentsSOM> v_StudentsSOM { get; set; }
    }
}
