using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_PROJECT_e_Adminstrator.Models;
using MVC_PROJECT_e_Adminstrator.Functions;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Controllers
{
    public class HomeController : Controller
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult signIn()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("index");
                
            }
        }

        [HttpPost]
        public ActionResult signIn(string ue,string p)
        {
            try
            {
                bool ck = false;
                Session["user"] = null;
                var s = from x in db.Admin_TB where x.NAME.Equals(ue) && x.PASSWORD.Equals(p) select x;
                foreach (var g in s)
                {
                    ck = true;
                }
                if (ck == true)
                {
                    Session["user"] = ue.ToString();
                    return RedirectToAction("index");
                }
                else
                {
                    var ss = from x in db.User_TB where x.EMAIL.Equals(ue) && x.PASSWORD.Equals(p) select x;
                    foreach (var g in ss)
                    {
                        ck = true;
                    }
                    if (ck == true)
                    {
                        Session["user"] = ue.ToString();
                        return RedirectToAction("index");
                    }
                    else
                    {
                        return RedirectToAction("signIn");
                    }
                }
            }
            catch 
            {
                return RedirectToAction("signIn");
            
            }
            
        }

        public ActionResult signOut()
        {
            Session.Clear();
            return RedirectToAction("index");
        }

    }
}
