using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Access.Models
{
    public class AccessDBContext:DbContext
    {
        public AccessDBContext():base("AccessDBContext")
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Hosting> Hostings { get; set; }
        public DbSet<HostingPackage> HostingPackages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        } 
    }
}