using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access.Models.ViewModels
{
    public class CreateDomainViewModel
    {
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public System.DateTime DomainRegistrationDate { get; set; }
        public System.DateTime DomainBillingDate { get; set; }
        public string RenewalPrice { get; set; }
        public bool DHStatus { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "CustomerName required")]
        public int CustomerId { get; set; }
        public string PageTitle { get; set; }
        public string CustomerName { get; set; }
        public List<Customer> domList { get; set; }
        public Customer Customer { get; set; }
    }
}