using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hmwrk6.Models;
using Hmwrk6.Models.ViewModels;


namespace Hmwrk6.Controllers
{
    public class HomeController : Controller
    {
        public WWIDbcontext db = new WWIDbcontext();

        public ActionResult Index(string query)
        {
            DisplayModel vm = new DisplayModel();
            if (query == null || query == "")
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                // display name results in a list
                ViewBag.show = true;
                return View(db.People.Where(x => x.FullName.ToUpper().Contains(query.ToUpper())).ToList());
            }
        }

        public ActionResult Details(int? id)
        {
            DisplayModel vm = new DisplayModel
            {
                MyPerson = db.People.Find(id)
            };
            ViewBag.IsP = false;

            if(vm.MyPerson.Customers2.Count() > 0)
            {
                ViewBag.IsP = true;
                int customerID = vm.MyPerson.Customers2.FirstOrDefault().CustomerID;
                vm.MyCustomer = db.Customers.Find(customerID);

                // the Gross Sales sum
                ViewBag.GrossSales = vm.MyCustomer.Orders.SelectMany(s => s.Invoices).SelectMany(p => p.InvoiceLines).Sum(x => x.ExtendedPrice);
                ViewBag.GrossProfit = vm.MyCustomer.Orders.SelectMany(s => s.Invoices).SelectMany(p => p.InvoiceLines).Sum(x => x.LineProfit);
                vm.MyInvoiceLine = vm.MyCustomer.Orders.SelectMany(y => y.Invoices).SelectMany(z => z.InvoiceLines).OrderByDescending(v => v.LineProfit).Take(10).ToList();
            }

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person thisPerson = db.People.Find(id);
            if(thisPerson == null)
            {
                return HttpNotFound();
            }
            return View("Details", vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}