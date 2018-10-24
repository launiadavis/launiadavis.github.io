using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            /// takes value entered in textbox from Converter and converts to a double
            double distance = Convert.ToDouble(Request.QueryString["miles"]);
            string measurement = Request.QueryString["metric"];
            // debugging
            Debug.WriteLine(distance);
            Debug.WriteLine(measurement);

            /// if, else if statements to go through and find metric that was seleced by user
            /// then computing the corresponding metric conversion once the seleced metric is found

            double result = 0;

            if(measurement == "millimeters")
            {
                result = distance * 1609344;
            }
            else if (measurement == "centimeters")
            {
                result = distance * 160934.4;
            }
            else if (measurement == "meters")
            {
                result = distance * 16093.44;
            }
            else if (measurement == "kilometers")
            {
                result = distance * 1609.344;
            }
            else
            {
                result = distance;
            }

            string message = "Your mile(s) conversion is: " + Convert.ToString(result) + " " + measurement;
            ViewBag.Message = message;
            return View();
        }


    }
}