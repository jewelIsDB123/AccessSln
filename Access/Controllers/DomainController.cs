using Access.BLL.Repositories;
using Access.Models;
using Access.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Access.Controllers
{
    public class DomainController : Controller
    {
        DomainRepository repobj = new DomainRepository();
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
            List<DomainListViewModel> domList = repobj.GetDomains();
            if (!string.IsNullOrEmpty(SearchString))
            {
                domList = domList.Where(p => p.DomainName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    domList = domList.OrderByDescending(n => n.DomainName).ToList();
                    break;
                default:
                    break;
            }
            int pageSize = 3;
            int pageNumber = (Page ?? 1);
            return View("Index", domList.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Create()
        {
            CreateDomainViewModel obj = new CreateDomainViewModel();
            obj.domList = repobj.GetCustomers();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateDomainViewModel viewObj)
        {
            var result = false;
            Domain domObj = new Domain();
            domObj.DomainName = viewObj.DomainName;
            domObj.DomainRegistrationDate = viewObj.DomainRegistrationDate;
            domObj.DomainBillingDate = viewObj.DomainBillingDate;
            domObj.RenewalPrice = viewObj.RenewalPrice;
            domObj.DHStatus = viewObj.DHStatus;
            domObj.Notes = viewObj.Notes;
            domObj.CustomerId = viewObj.CustomerId;

            if (ModelState.IsValid)
            {
                if (viewObj.DomainId == 0)
                {
                    repobj.SaveDomain(domObj);
                    result = true;
                }
                else
                {
                    domObj.DomainId = viewObj.DomainId;
                    repobj.UpdateDomain(domObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.DomainId == 0)
                {
                    return View("Create");
                }
                else
                {
                    return View("Edit");
                }
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Domain proObj = repobj.GetDomainById(id);
            CreateDomainViewModel viewObj = new CreateDomainViewModel();
            viewObj.DomainId = proObj.DomainId;
            viewObj.DomainName = proObj.DomainName;
            viewObj.DomainRegistrationDate = proObj.DomainRegistrationDate;
            viewObj.DomainBillingDate = proObj.DomainBillingDate;
            viewObj.RenewalPrice = proObj.RenewalPrice;
            viewObj.DHStatus = proObj.DHStatus;
            viewObj.Notes = proObj.Notes;
            viewObj.CustomerId = proObj.CustomerId;
            viewObj.domList = repobj.GetCustomers();
            return View(viewObj);
        }
        public ActionResult Delete(int id)
        {
            Domain obj = repobj.GetDomainById(id);
            repobj.DeleteDomain(obj.DomainId);
            return RedirectToAction("Index");
        }

    }
}