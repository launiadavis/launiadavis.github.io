using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hmwk8.DAL;



namespace Hmwk8.Controllers
{
   
    public class HomeController : Controller
    {
        private HW8Context db = new HW8Context(); // create new db object

        public ActionResult Index()
        {
            return View(db.Bids.OrderByDescending (x => x.BidTIMESTAMP).Take(10).ToList());
        }

    }
}