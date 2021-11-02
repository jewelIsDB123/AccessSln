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
    public class DomainRepository : IDomainRepository
    {
        AccessDBContext db = new AccessDBContext();
        public void DeleteDomain(int id)
        {
            Domain delobj = GetDomainById(id);
            db.Domains.Remove(delobj);
            db.SaveChanges();
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> domList = db.Customers.ToList();
            return domList;
        }

        public Domain GetDomainById(int id)
        {
            Domain obj = db.Domains.SingleOrDefault(p => p.DomainId == id);
            return obj;
        }

        public List<DomainListViewModel> GetDomains()
        {
            List<DomainListViewModel> viewlist = new List<DomainListViewModel>();
            List<Domain> list = db.Domains.ToList();
            viewlist = db.Domains.Select(p => new DomainListViewModel
            {
                DomainId = p.DomainId,
                DomainName = p.DomainName,
                DomainRegistrationDate = p.DomainRegistrationDate,
                DomainBillingDate = p.DomainBillingDate,
                RenewalPrice = p.RenewalPrice,
                DHStatus = p.DHStatus,
                Notes = p.Notes,
                CustomerId = p.CustomerId,
                CustomerName = p.Customer.CustomerName,
                PageTitle = "Domain List"
            }).ToList();
            return viewlist;
        }

        public void SaveDomain(Domain obj)
        {
            db.Domains.Add(obj);
            db.SaveChanges();
        }
        public void UpdateDomain(Domain obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}