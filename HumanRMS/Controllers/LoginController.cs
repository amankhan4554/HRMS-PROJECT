using HumanRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HumanRMS.Controllers
{
    public class LoginController : Controller
    {
        
        HRMSEntities db = new HRMSEntities();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(employee_info acc)
        {
            
            using (var context = new HRMSEntities())
            {

                try
                {
                    
                    bool isValid = context.employee_info.Any(x => x.emp_cnic == acc.emp_cnic && x.emp_email == acc.emp_email);
                    if (isValid)
                    {

                        ModelState.AddModelError("", "Your CNIC number does not exist");
                        return View();
                    }
                    FormsAuthentication.SetAuthCookie(acc.emp_email, false);
                    return RedirectToAction("Dashbord", "Employee");

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}