using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access.Models
{
    public class Hosting
    {
        public int HostingId { get; set; }
        public System.DateTime HostingDate { get; set; }
        public System.DateTime HostingBillingDate { get; set; }
        public string HostingRenewalPrice { get; set; }
        public string OtherServices { get; set; }
        public int CustomerId { get; set; }
        public int HostingPackageId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual HostingPackage HostingPackage { get; set; }

    }
}