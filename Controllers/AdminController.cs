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
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public bool check() 
        {
           bool ck = false;
           string s = Session["user"].ToString();
           if (s == null)
           {
               ck = false;
           }
           else 
           {
               var ss = from x in db.Admin_TB where x.NAME.Equals(s) select x;
               foreach (var g in ss) 
               {
                   ck = true;
               }
           }
            return ck;
        }

        public ActionResult Index()
        {
            bool ck = check();
            if (ck == true)
            {
                functions f = new functions();
                ViewBag.dep = f._selDep();
                ViewBag.users = f._selUsers();
                ViewBag.bth = f._selBatch();
                ViewBag.stu = f._selStudent();
                ViewBag.lab = f._sellabs();
                ViewBag.lt = f._selTimetable();
                ViewBag.com = f._selComplaints();

                return View();
            }
            else 
            {
                return RedirectToAction("index", "Home");
            }
        }
        //.......................DEP ADD KAAM START....................................//

        public ActionResult addDep() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult addDep(Dep d)
        {
            Department dd = new Functions.Department();
            dd.insert(d);
            return RedirectToAction("Index");

        }

        //.......................DEP ADD KAAM END....................................//




        //.......................DEP DEKETE KAAM START....................................//

        public ActionResult deleteDep(int id) 
        {
            Department d = new Functions.Department();
            d.delete(id);
            return RedirectToAction("Index");
        }
        //.......................DEP DEKETE KAAM END....................................//

        //.......................USER ADD KAAM START....................................//

        public ActionResult addUser() 
        {
            var dname = (from x in db.Dep_TB select new { x.Dep_Name }).Distinct();
            ViewBag.dname1 = new SelectList(dname, "Dep_Name", "Dep_Name");

            var drole = (from x in db.Dep_TB select new { x.Role_Dep_Name }).Distinct(); 
            ViewBag.drole1 = new SelectList(drole, "Role_Dep_Name", "Role_Dep_Name");

            return View();
            
        }

        [HttpPost]
        public ActionResult addUser(Users u, DateTime dob, string dname1, string drole1) 
        {
            UsersMethos um = new Functions.UsersMethos();
            um.insert(u, dob, dname1, drole1);

            return RedirectToAction("addUser");
        }
        //.......................USER ADD KAAM END....................................//

        //.......................USER EDIT KAAM START....................................//

        public ActionResult editUser(int id)
        {
            Users u = new Users();
            User_TB ut = db.User_TB.Find(id);
            u.u_NAME = ut.NAME;
            u.u_FATHER_NAME = ut.FATHER_NAME;
            u.u_CNIC = ut.CNIC;
            u.u_DOB = (DateTime)ut.DOB;
            u.u_PHONE = ut.PHONE;
            u.u_ADDRESS = ut.ADDRESS;
            u.u_EMAIL = ut.EMAIL;

            var dname = (from x in db.Dep_TB select new { x.Dep_Name }).Distinct();
            ViewBag.dname1 = new SelectList(dname, "Dep_Name", "Dep_Name");

            var drole = (from x in db.Dep_TB select new { x.Role_Dep_Name }).Distinct();
            ViewBag.drole1 = new SelectList(drole, "Role_Dep_Name", "Role_Dep_Name");

            return View(u);
        }
        //.......................USER EDIT KAAM END....................................//

        //.......................USER DELETE KAAM START....................................//
        public ActionResult deleteUser(int id) 
        {
            UsersMethos u = new Functions.UsersMethos();
            u.delete(id);
            return RedirectToAction("Index");
        }
        
        //.......................USER DELETE KAAM END....................................//

        //.......................BATCH ADD KAAM START....................................//

        public ActionResult addbth() 
        {
            var s = from x in db.User_TB select x;
            ViewBag.teach = new SelectList(s, "ID", "NAME");

            return View();
        }

        [HttpPost]
        public ActionResult addbth(batchModel bb, int teach)
        {
            Batch b = new Functions.Batch();
            b.insert(bb, teach);
            return RedirectToAction("addbth");
        }
        //.......................BATCH ADD KAAM END....................................//

        //.......................BATCH DELETE KAAM START....................................//

        public ActionResult deletebth(int id) 
        {
            Batch b = new Functions.Batch();
            b.delete(id);
            return RedirectToAction("Index");
            
        }
        //.......................BATCH DELETE KAAM END....................................//

        //.......................STUDENT ADD KAAM START....................................//

        public ActionResult addStu() 
        {
            var bt = from x in db.Batch_TB where x.STATUS == true select x;
            ViewBag.bt = new SelectList(bt, "ID", "BATCH_CODE");
            return View();
        }

        [HttpPost]
        public ActionResult addStu(Student u, DateTime dob, int bt)
        {
            StudentMethos s = new Functions.StudentMethos();
            int a = s.insert(u, dob, bt);
            if (a > 0)
            {
                ViewBag.r = "Student Added";
            }
            else 
            {
                ViewBag.r = "Some Error";
            }
            return RedirectToAction("addStu");
        }

        //.......................STUDENT ADD KAAM END....................................//

        //.......................STUDENT DELETE KAAM END....................................//

        public ActionResult deleteStu(int id) 
        {
            StudentMethos s = new StudentMethos();
            s.delete(id);
            return RedirectToAction("index");
        }

        //.......................STUDENT DELETE KAAM END....................................//


        //.......................LAB KAAM START....................................//

        public ActionResult addLab()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addLab(labModel lm)
        {
            labMethods l = new Functions.labMethods();
            l.insert(lm);
            return RedirectToAction("addLab");

        }
        
        public ActionResult editLab(int id)
        {
            labModel l = new labModel();
            Lab_TB lt = db.Lab_TB.Find(id);
            l.labName = lt.Lab_Name;
            l.labId = lt.ID;

            return View(l);        
        }

        [HttpPost]
        public ActionResult editLab(int id,labModel lm)
        {
            labMethods l = new Functions.labMethods();
            l.edit(lm, id);
            return RedirectToAction("editLab");
        }

        public ActionResult deleteLab(int id) 
        {
            labMethods l = new Functions.labMethods();
            l.delete(id);
            return RedirectToAction("index");
        
        }

        //.......................LAB KAAM END....................................//

        //.......................LAB TIMMING KAAM START....................................//

        public ActionResult addLt()
        {
            var b = from x in db.Batch_TB where x.STATUS == true select x;
            ViewBag.b = new SelectList(b, "ID", "BATCH_CODE");

            var l = from x in db.Lab_TB where x.STATUS == true select x;
            ViewBag.l = new SelectList(l, "ID", "Lab_Name");
            return View();
        }

        [HttpPost]
        public ActionResult addLt(int b, int l, string time, string days)
        {
            labTimmingMethods ll = new Functions.labTimmingMethods();
            ll.insert(b, l, time, days);
            return RedirectToAction("addLt");
        }

        public ActionResult editLt()
        {
            var b = from x in db.Batch_TB where x.STATUS == true select x;
            ViewBag.b = new SelectList(b, "ID", "BATCH_CODE");

            var l = from x in db.Lab_TB where x.STATUS == true select x;
            ViewBag.l = new SelectList(l, "ID", "Lab_Name");

            return View();
        }

        [HttpPost]
        public ActionResult editLt(int id,int b, int l, string time, string days)
        {
            labTimmingMethods ll = new Functions.labTimmingMethods();
            ll.edit(id, b, l, time, days);
            return RedirectToAction("editLt");
        }

        public ActionResult deleteLt(int id) 
        {
            labTimmingMethods ll = new Functions.labTimmingMethods();
            ll.delete(id);
            return RedirectToAction("index");
        }
        //.......................LAB TIMMING KAAM END....................................//

        //.......................COMP KAAM START....................................//
        //.......................COMP KAAM END....................................//

        public ActionResult search() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult search(string val,string s)
        {
            functions f = new functions();
            f._Allsel(s, val);
            return View();
        }
        ////////end//////////./.....................
    }
}
