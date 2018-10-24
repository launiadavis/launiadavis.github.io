using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Diagnostics;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ColorController : Controller
    {
        [HttpGet]
        public ActionResult ColorChooser()
        {
            ViewBag.show = false;
            return View();
        }

        [HttpPost]
        public ActionResult ColorChooser(string ColorNum1, string ColorNum2)
        {
            ViewBag.Message = "Please enter colors in HTML hexadecimal format: #AABBCC";

            ColorNum1 = Request.Form["Color1"];
            ColorNum2 = Request.Form["Color2"];
            /// let's debug
            Debug.WriteLine(ColorNum1);
            Debug.WriteLine(ColorNum2);
            /// checking the values of object with these variables
            int colorA;
            int colorR;
            int colorB;
            int colorG;

            /// values entered by users are turned into Hex and then color object
            Color C1 = ColorTranslator.FromHtml(ColorNum1);
            Color C2 = ColorTranslator.FromHtml(ColorNum2);

            /// going through and figuring out arbg color nums
            if (C1.A + C2.A >= 255)
            {
                colorA = 255;
            }
            else
            {
                colorA = C1.A + C2.A;
            }
            if (C1.R + C2.R >= 255)
            {
                colorR = 255;
            }
            else
            {
                colorR = C1.R + C2.R;
            }
            if (C1.B + C2.B >= 255)
            {
                colorB = 255;
            }
            else
            {
                colorB = C1.B + C2.B;
            }
            if (C1.G + C2.G >= 255)
            {
                colorG = 255;
            }
            else
            {
                colorG = C1.G + C2.G;
            }

            /// take all the values above and mix the colors
            string mixedColor = ColorTranslator.ToHtml(Color.FromArgb(colorA, colorR, colorB, colorG));
            /// creating boxes to hold the 2 colors user chose and the 3rd mixed color
            if (ColorNum1 != null && ColorNum2 != null)
            {
                /// view connection to ColorChooser to display color boxes
                ViewBag.show = true;

                ViewBag.shape1 = "width: 50px; height:50px; border: 1px solid #000; background:" + ColorNum1 + ";";
                ViewBag.shape2 = "width: 50px; height:50px; border: 1px solid #000; background:" + ColorNum2 + ";";
                ViewBag.shape3 = "width: 50px; height:50px; border: 1px solid #000; background:" + mixedColor + ";";
            }

            return View();
        }
    }
}