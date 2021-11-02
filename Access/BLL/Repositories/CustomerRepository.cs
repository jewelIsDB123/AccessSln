using Access.BLL.Interfaces;
using Access.Models;
using Access.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Access.BLL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        AccessDBContext db = new AccessDBContext();
        public void DeleteCustomer(int id)
        {
            Customer delobj = GetCustomerById(id);
            db.Customers.Remove(delobj);
            db.SaveChanges();
        }
        public Customer GetCustomerById(int id)
        {
            Customer obj = db.Customers.SingleOrDefault(p => p.CustomerId == id);
            return obj;
        }
        public List<CustomerListViewModel> GetCustomers()
        {
            List<CustomerListViewModel> viewlist = new List<CustomerListViewModel>();
            List<Customer> list = db.Customers.ToList();
            viewlist = db.Customers.Select(p => new CustomerListViewModel
            {
                CustomerId = p.CustomerId,
                CustomerName = p.CustomerName,
                Company = p.Company,
                Designation = p.Designation,
                City = p.City,
                Country = p.Country,
                Fax = p.Fax,
                ActiveStatus = p.ActiveStatus,
                Address = p.Address,
                Notes = p.Notes,
                Email01 = p.Email01,
                Email02 = p.Email02,
                Email03 = p.Email03,
                Email04 = p.Email04,
                Contact01 = p.Contact01,
                Contact02 = p.Contact02,
                Contact03 = p.Contact03,
                Contact04 = p.Contact04,
                PageTitle = "Customer List",
            }).ToList();
            return viewlist;
        }
        public void SaveCustomer(Customer obj)
        {
            db.Customers.Add(obj);
            db.SaveChanges();
        }
        public void UdpateCustomer(Customer obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}