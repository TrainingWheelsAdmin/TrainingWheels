using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxy;
using Service;
using ServiceContracts;

namespace TrainingApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            if (string.IsNullOrEmpty(formCollection["CompanyName"].ToString()))
            {
                ModelState.AddModelError("companyname", "Please enter Company name");
            }

            return View();
        }
    }
}