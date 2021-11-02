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
    public class HostingRepository : IHostingRepository
    {
        public AccessDBContext db = new AccessDBContext();
        public void DeleteHosting(int id)
        {
            Hosting delObj = GetHostingById(id);
            db.Hostings.Remove(delObj);
            db.SaveChanges();
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> hostList = db.Customers.ToList();
            return hostList;
        }

        public Hosting GetHostingById(int id)
        {
            Hosting obj = db.Hostings.SingleOrDefault(p => p.HostingId == id);
            return obj;

        }

        public List<HostingPackage> GetHostingPackages(int id)
        {
            List<HostingPackage> hostList = db.HostingPackages.ToList();
            return hostList;
        }

        public List<HostingPackage> GetHostingPackages()
        {
            List<HostingPackage> hdList = db.HostingPackages.ToList();
            return hdList;
        }

        public List<HostingListViewModel> GetHostings()
        {
            List<HostingListViewModel> viewlist = new List<HostingListViewModel>();
            List<Hosting> List = db.Hostings.ToList();
            viewlist = db.Hostings.Select(p => new HostingListViewModel
            {
                HostingId=p.HostingId,
                HostingDate=p.HostingDate,
                HostingBillingDate=p.HostingBillingDate,
                HostingRenewalPrice=p.HostingRenewalPrice,
                OtherServices=p.OtherServices,
                CustomerId=p.CustomerId,
                CustomerName=p.Customer.CustomerName,
                HostingPackageId=p.HostingPackageId,
                HostingPackageName=p.HostingPackage.HostingPackageName,
                PageTitle="Hosting List"

            }).ToList();
            return viewlist;
        }

        public void SaveHosting(Hosting obj)
        {
            db.Hostings.Add(obj);
            db.SaveChanges();
        }

        public void UpdateHosting(Hosting obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}