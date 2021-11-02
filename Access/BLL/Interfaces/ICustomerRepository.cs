using Access.Models;
using Access.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access.BLL.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerListViewModel> GetCustomers();
        Customer GetCustomerById(int id);
        void SaveCustomer(Customer obj);
        void UdpateCustomer(Customer obj);
        void DeleteCustomer(int id);
    }
}