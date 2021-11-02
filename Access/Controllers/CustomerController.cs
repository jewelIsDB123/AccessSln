using Access.BLL.Repositories;
using Access.Models;
using Access.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Access.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository repobj = new CustomerRepository();
        public ActionResult Index(string SearchString, string CurrentFilter, string sortOrder, int? Page)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            List<CustomerListViewModel> prodList = repobj.GetCustomers();
            if (!string.IsNullOrEmpty(SearchString))
            {
                prodList = prodList.Where(n => n.CustomerName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    prodList = prodList.OrderByDescending(n => n.CustomerName).ToList();
                    break;
                default:
                    break;
            }
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return View("Index",prodList.ToPagedList(PageNumber, PageSize));
        }
        public ActionResult Create()
        {
            CreateCustomerViewModel obj = new CreateCustomerViewModel();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateCustomerViewModel viewObj)
        {
            var result = false;
            Customer studObj = new Customer();
            studObj.CustomerName = viewObj.CustomerName;
            studObj.Company = viewObj.Company;
            studObj.Designation = viewObj.Designation;
            studObj.City = viewObj.City;
            studObj.Country = viewObj.Country;
            studObj.Fax = viewObj.Fax;
            studObj.ActiveStatus = viewObj.ActiveStatus;
            studObj.Address = viewObj.Address;
            studObj.Notes = viewObj.Notes;
            studObj.Email01 = viewObj.Email01;
            studObj.Email02 = viewObj.Email02;
            studObj.Email03 = viewObj.Email03;
            studObj.Email04 = viewObj.Email04;
            studObj.Contact01 = viewObj.Contact01;
            studObj.Contact02 = viewObj.Contact02;
            studObj.Contact03 = viewObj.Contact03;
            studObj.Contact04 = viewObj.Contact04;

            if (ModelState.IsValid)
            {
                if (viewObj.CustomerId == 0)
                {
                    repobj.SaveCustomer(studObj);
                    result = true;
                }
                else
                {
                    studObj.CustomerId = viewObj.CustomerId;
                    repobj.UdpateCustomer(studObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.CustomerId == 0)
                {
                    CreateCustomerViewModel obj = new CreateCustomerViewModel();
                    return View("Create", obj);
                }
                else
                {
                    CreateCustomerViewModel obj = new CreateCustomerViewModel();
                    return View("Edit", obj);
                }
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer custList = repobj.GetCustomerById(id);
            CreateCustomerViewModel viewObj = new CreateCustomerViewModel();
            viewObj.CustomerId = custList.CustomerId;
            viewObj.CustomerName = custList.CustomerName;
            viewObj.Company = custList.Company;
            viewObj.Designation = custList.Designation;
            viewObj.City = custList.City;
            viewObj.Country = custList.Country;
            viewObj.Fax = custList.Fax;
            viewObj.ActiveStatus = custList.ActiveStatus;
            viewObj.Address = custList.Address;
            viewObj.Notes = custList.Notes;
            viewObj.Email01 = custList.Email01;
            viewObj.Email02 = custList.Email02;
            viewObj.Email03 = custList.Email03;
            viewObj.Email04 = custList.Email04;
            viewObj.Contact01 = custList.Contact01;
            viewObj.Contact02 = custList.Contact02;
            viewObj.Contact03 = custList.Contact03;
            viewObj.Contact04 = custList.Contact04;
            return View(viewObj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer custList = repobj.GetCustomerById(id);
            repobj.DeleteCustomer(custList.CustomerId);
            return RedirectToAction("Index");
        }
    }
}