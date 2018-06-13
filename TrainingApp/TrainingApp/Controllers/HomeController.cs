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
            CheckAdminCredentialProxy CheckAdminCredentialProxy = new CheckAdminCredentialProxy(new CheckAdminCredentialService());
            CheckAdminCredentialProxy.CheckAdminCredential(null, "admin@training.com", "5458AE2DF3A2FFA892291F45FA909FD3");
            return View();
        }
    }
}