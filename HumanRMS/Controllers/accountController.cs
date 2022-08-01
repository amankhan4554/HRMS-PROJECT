using HumanRMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HumanRMS.Controllers
{
    [AllowAnonymous]
    public class accountController : Controller
    {
        
         

        // GET: account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin_log acc)
        {
            using (var context = new HRMSEntities())
                
            
                
                {
                    bool isValid = context.admin_log.Any(x => x.admin_email == acc.admin_email && x.admin_password == acc.admin_password);

                    if (isValid)
                    {
                        FormsAuthentication.SetAuthCookie(acc.admin_email, false);
                        TempData["name"] = "Aman Khan"; 
                        return RedirectToAction("Dashboard", "Admin");

                    }
                    ModelState.AddModelError("", "Invalid email and Password");
                    return View();
                }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

      

    }
}