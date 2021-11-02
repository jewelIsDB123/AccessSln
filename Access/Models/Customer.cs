using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public bool ActiveStatus { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Email01 { get; set; }
        public string Email02 { get; set; }
        public string Email03 { get; set; }
        public string Email04 { get; set; }
        public string Contact01 { get; set; }
        public string Contact02 { get; set; }
        public string Contact03 { get; set; }
        public string Contact04 { get; set; }
        public virtual ICollection<Domain> Domains { get; set; }
        public virtual ICollection<Hosting> Hostings { get; set; }
    }
}