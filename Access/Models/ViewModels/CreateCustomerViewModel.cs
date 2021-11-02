using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Access.Models.ViewModels
{
    public class CreateCustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter Customer name Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Enter Company name Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Company Name")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Enter Current Designation Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Designation Name")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Enter Current City Required")]
        [DataType(DataType.Text)]
        [Display(Name = "City Name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter Current Country Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Country Name")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Enter Current Fax Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }
        public bool ActiveStatus { get; set; }
        [Required(ErrorMessage = "Enter Current Address Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Enter Notes Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Notes")]
        public string Notes { get; set; }
        [Required(ErrorMessage = "Enter Email address Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email01 { get; set; }
        [Required(ErrorMessage = "Enter Email address Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email02 { get; set; }
        [Required(ErrorMessage = "Enter Email address Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email03 { get; set; }
        [Required(ErrorMessage = "Enter Email address Required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email04 { get; set; }
        [Required(ErrorMessage = "Enter Contact 01 Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Contact 01")]
        public string Contact01 { get; set; }
        [Required(ErrorMessage = "Enter Contact 02 Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Contact 02")]
        public string Contact02 { get; set; }
        [Required(ErrorMessage = "Enter Contact 03 Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Contact 03")]
        public string Contact03 { get; set; }
        [Required(ErrorMessage = "Enter Contact 04 Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Contact 04")]
        public string Contact04 { get; set; }
        public string PageTitle { get; set; }
    }
}