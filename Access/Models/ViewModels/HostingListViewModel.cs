using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access.Models.ViewModels
{
    public class HostingListViewModel
    {
        public int HostingId { get; set; }
        public System.DateTime HostingDate { get; set; }
        public System.DateTime HostingBillingDate { get; set; }
        public string HostingRenewalPrice { get; set; }
        public string OtherServices { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int HostingPackageId { get; set; }
        public string HostingPackageName { get; set; }
        public string PageTitle { get; set; }
        public Customer Customer { get; set; }
        public HostingPackage HostingPackage { get; set; }
        public List<Customer> customers { get; set; }
        public List<HostingPackage> hostingPackages { get; set; }
    }
}