using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access.Models.ViewModels
{
    public class DomainListViewModel
    {
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public System.DateTime DomainRegistrationDate { get; set; }
        public System.DateTime DomainBillingDate { get; set; }
        public string RenewalPrice { get; set; }
        public bool DHStatus { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public string PageTitle { get; set; }
        public string CustomerName { get; set; }
        public  Customer Customer { get; set; }
        public List<Customer> customers { get; set; }
    }
}