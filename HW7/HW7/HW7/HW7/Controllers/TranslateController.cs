using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class TranslateController : Controller
    {
        // GET: TranslateImage
        // In this controller a request is created and json data can then be recieved, parsed and returned
        public JsonResult TranslateImage(string imageWord)
        {
            string uri = "https://api.giphy.com/v1/stickers/translate?api_key=" + System.Web.Configuration.WebConfigurationManager.AppSettings["AdminKey"] + "&s=" + imageWord;

            //the web request is created
            WebRequest dataWebRequest = WebRequest.Create(uri);

            //get JSON data
            Stream dataStream = dataWebRequest.GetResponse().GetResponseStream();

            //parse recieved JSON data
            var parsedJsonData = new System.Web.Script.Serialization.JavaScriptSerializer().DeserializeObject(new StreamReader(dataStream).ReadToEnd());

            return Json(parsedJsonData, JsonRequestBehavior.AllowGet);
        }
    }
}