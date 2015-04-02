using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace MvcPrimer.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            string[] files = Directory.GetFiles(@"C:\inetpub\wwwroot\w04a\MvcPrimer\somedata")
                 .Select(path => Path.GetFileName(path)).ToArray();

            ViewData["files"] = files;

            //ViewBag.MyMessage = "This is my process index action method";
            return View();
        }

        public ActionResult Content(string filename)
        {

            string filepath = Server.MapPath("../somedata/") + filename;
            System.IO.StreamReader rdr = new System.IO.StreamReader(filepath);
            ViewData["data"] = rdr.ReadToEnd();
            rdr.Close();

            return View();

        }
    }
}