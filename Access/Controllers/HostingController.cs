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
    public class HostingController : Controller
    {
        // GET: Hosting
        HostingRepository  repobj = new HostingRepository();
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
            List<HostingListViewModel> hostList = repobj.GetHostings();
            if (!string.IsNullOrEmpty(SearchString))
            {
                hostList = hostList.Where(n => n.CustomerName.ToUpper().Contains(SearchString.ToUpper())).ToList();
              
            }
            switch (sortOrder)
            {
                case "name_desc":
                    hostList = hostList.OrderByDescending(n => n.CustomerName).ToList();
                    break;
                default:
                    break;
            }
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return View("Index", hostList.ToPagedList(PageNumber, PageSize));


            
            
        }
        public ActionResult Create()
        {
            CreateHostingViewModel obj = new CreateHostingViewModel();
            obj.hostList = repobj.GetCustomers();
            obj.hpList = repobj.GetHostingPackages();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateHostingViewModel viewObj)
        {
            var result = false;
            Hosting hostObj = new Hosting();
            hostObj.HostingDate = viewObj.HostingDate;
            hostObj.HostingBillingDate = viewObj.HostingBillingDate;
            hostObj.HostingRenewalPrice = viewObj.HostingRenewalPrice;
            hostObj.OtherServices = viewObj.OtherServices;
            hostObj.CustomerId = viewObj.CustomerId;
            hostObj.HostingPackageId = viewObj.HostingPackageId;
            if (ModelState.IsValid)
            {
                if (viewObj.HostingId == 0)
                {
                    repobj.SaveHosting(hostObj);
                    result = true;
                }
                else
                {
                    hostObj.HostingId = viewObj.HostingId;
                    repobj.UpdateHosting(hostObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.HostingId == 0)
                {
                    CreateHostingViewModel obj = new CreateHostingViewModel();
                    obj.hostList = repobj.GetCustomers();
                    obj.hpList = repobj.GetHostingPackages();
                    return View("Create", obj);
                }
                else
                {
                    CreateHostingViewModel obj = new CreateHostingViewModel();
                    obj.hostList = repobj.GetCustomers();
                    obj.hpList = repobj.GetHostingPackages();
                    return View("Edit", obj);
                }
            }
        }
        public ActionResult Edit(int id)
        {
            Hosting hostObj = repobj.GetHostingById(id);
            CreateHostingViewModel viewObj = new CreateHostingViewModel();
            viewObj.HostingId = hostObj.HostingId;
            viewObj.HostingDate = hostObj.HostingDate;
            viewObj.HostingBillingDate = hostObj.HostingBillingDate;
            viewObj.HostingRenewalPrice = hostObj.HostingRenewalPrice;
            viewObj.OtherServices = hostObj.OtherServices;
            viewObj.CustomerId = hostObj.CustomerId;
            viewObj.CustomerId = hostObj.CustomerId;
            viewObj.hostList = repobj.GetCustomers();
            viewObj.HostingPackageId = hostObj.HostingPackageId;
            viewObj.hpList = repobj.GetHostingPackages();
            return View(viewObj);
        }
        public ActionResult Delete(int id)
        {
            Hosting obj = repobj.GetHostingById(id);
            repobj.DeleteHosting(obj.HostingId);
            return RedirectToAction("Index");
        }
    }
}
