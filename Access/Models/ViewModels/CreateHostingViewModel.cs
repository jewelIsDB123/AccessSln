using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access.Models.ViewModels
{
    public class CreateHostingViewModel
    {
        public int HostingId { get; set; }
        public System.DateTime HostingDate { get; set; }
        public System.DateTime HostingBillingDate { get; set; }
        public string HostingRenewalPrice { get; set; }
        public string OtherServices { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "CustomerName required")]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Display(Name = "HostingPackage Name")]
        [Required(ErrorMessage = "HostingPackageName required")]
        public int HostingPackageId { get; set; }
        public string HostingPackageName { get; set; }
        public string PageTitle { get; set; }
        public Customer Customer { get; set; }
        public HostingPackage HostingPackage { get; set; }
        public List<Customer> hostList { get; set; }
        public List<HostingPackage> hpList { get; set; }
    }
}