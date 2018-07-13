using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using Proxy;
using Service;
using ServiceContracts;
using CredCipherService;
using Microsoft.AspNet.SignalR.Hubs;
using System.Web.Security;
using Microsoft.AspNet.SignalR;

namespace TrainingApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            //if ticket not expired
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (!ticket.Expired)
                {
                    return RedirectToAction("Home");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            //if ticket not expired
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (!ticket.Expired)
                {
                    return RedirectToAction("Home");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            if (string.IsNullOrEmpty(formCollection["EmailAddress"].ToString().Trim()))
            {
                ModelState.AddModelError("emailaddress", "Please enter Email Address");
            }
            if(string.IsNullOrEmpty(formCollection["Password"].ToString().Trim()))
            {
                ModelState.AddModelError("password", "Please enter Password");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    CheckAdminCredentialProxy checkAdminCredentialProxy = new CheckAdminCredentialProxy(new CheckAdminCredentialService());
                    bool result = checkAdminCredentialProxy.CheckAdminCredential(null, formCollection["EmailAddress"].ToString().Trim(), CipherService.GetCipherCreds(formCollection["Password"].ToString()));
                    if (result)
                    {
                        FormsAuthentication.SetAuthCookie(formCollection["EmailAddress"].ToString(), false);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, formCollection["EmailAddress"].ToString().Trim(), DateTime.Now, DateTime.Now.AddMinutes(10), false, "admin");
                        HttpCookie cookie1 = new HttpCookie(
                            FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket));
                        Response.Cookies.Add(cookie1);
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        ModelState.AddModelError("AuthenticationError", "invalid username and/or password");
                    }
                }
                
            }
            catch (Exception e)
            {

            }

            return View();
        }
        public ActionResult Home()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            //if ticket expired
            if(authCookie!=null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                if (ticket.Expired)
                {
                    return RedirectToAction("Login");
                }
            }
            //if cache cleared
            else
            {
                return RedirectToAction("Login");
            }


            
            return View();
        }
    }
}