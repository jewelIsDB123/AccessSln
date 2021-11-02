using Access.Models;
using Access.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.BLL.Interfaces
{
    public interface IDomainRepository
    {
        List<DomainListViewModel> GetDomains();
        Domain GetDomainById(int id);
        void SaveDomain(Domain obj);
        void UpdateDomain(Domain obj);
        void DeleteDomain(int id);
        List<Customer> GetCustomers(); 
    }
}
