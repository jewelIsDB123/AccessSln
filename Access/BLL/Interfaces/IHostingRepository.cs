using Access.Models;
using Access.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access.BLL.Interfaces
{
    public interface IHostingRepository
    {
        List<HostingListViewModel> GetHostings();
        Hosting GetHostingById(int id);
        void SaveHosting(Hosting obj);
        void UpdateHosting(Hosting obj);
        void DeleteHosting(int id);
        List<Customer> GetCustomers();
        List<HostingPackage> GetHostingPackages();
    }
}