using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Data.Linq.SqlClient;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class functions
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public List<Dep> _selDep() 
        {
            List<Dep> obj_Dep = new List<Dep>();

            var sel = (from x in db.Dep_TB select x).OrderByDescending(m => m.ID);
            foreach (var d in sel) 
            {
                Dep dd = new Dep();
                dd.Dep_ID = d.ID;
                dd.Dep_name = d.Dep_Name;
                dd.Dep_role = d.Role_Dep_Name;

                obj_Dep.Add(dd);
            }
            return obj_Dep;
        }



        public List<Users> _selUsers()
        {

            List<Users> obj_users = new List<Users>();


            var selusers = (from x in db.User_TB
                           join dep in db.Dep_TB on x.Dep_ID equals dep.ID
                           where x.STATUS == true
                           select new
                           {
                               x.ID,
                               x.NAME,
                               x.FATHER_NAME,
                               x.CNIC,
                               x.DOB,
                               x.PHONE,
                               x.ADDRESS,
                               x.EMAIL,
                               x.PASSWORD,
                               dep.Dep_Name,
                               dep.Role_Dep_Name
                           }).OrderByDescending(m => m.ID);

            foreach (var get in selusers)
            {
                Users u = new Users();
                u.u_id = get.ID;
                u.u_NAME = get.NAME;
                u.u_FATHER_NAME = get.FATHER_NAME;
                u.u_CNIC = get.CNIC;
                u.u_DOB = (DateTime)get.DOB;
                u.u_PHONE = get.PHONE;
                u.u_ADDRESS = get.ADDRESS;
                u.u_EMAIL = get.EMAIL;
                u.u_PASSWORD = get.PASSWORD;
                u.u_Dep_name = get.Dep_Name;
                u.u_Dep_role = get.Role_Dep_Name;

                obj_users.Add(u);

            }

            return obj_users;
        }

        public List<batchModel> _selBatch() 
        {
            List<batchModel> obj = new List<batchModel>();

            var s = (from x in db.Batch_TB
                    join u in db.User_TB on x.USERS_ID equals u.ID
                    join d in db.Dep_TB on u.Dep_ID equals d.ID
                    where x.STATUS == true
                    select new
                    {
                        x.ID,
                        x.BATCH_CODE,
                        x.BATCH_SESSION,
                        x.CREATED_DATE,
                        u.NAME,
                        d.Dep_Name,
                        d.Role_Dep_Name
                    }).OrderByDescending(m => m.ID);
            foreach (var g in s) 
            {
                batchModel b = new batchModel();
                b._bid = g.ID;
                b._bname = g.NAME;
                b._bsession = g.BATCH_SESSION;
                b._bdate = (DateTime)g.CREATED_DATE;
                b._busername = g.NAME;
                b._bdep = g.Dep_Name;
                b._bdeprole = g.Role_Dep_Name;

                obj.Add(b);
            }

            return obj;
        }

        public List<Student> _selStudent() 
        {
            List<Student> obj = new List<Student>();
            var s = (from x in db.Sudent_TB
                    join b in db.Batch_TB on x.BATCH_ID equals b.ID
                    join u in db.User_TB on b.USERS_ID equals u.ID
                    join d in db.Dep_TB on u.Dep_ID equals d.ID
                    where x.STATUS == true
                    select new
                    {
                        x.ID,
                        x.NAME,
                        x.FATHER_NAME,
                        x.CNIC,
                        x.DOB,
                        x.PHONE,
                        x.ADDRESS,
                        x.EMAIL,
                        b.BATCH_CODE,
                        b.BATCH_SESSION

                    }).OrderByDescending(m => m.ID);
            foreach (var g in s) 
            {
                Student st = new Student();
                st._sid = g.ID;
                st._sname = g.NAME;
                st._sFATHER_NAME = g.FATHER_NAME;
                st._sCNIC = g.CNIC;
                st._sDOB = (DateTime)g.DOB;
                st._sPHONE = g.PHONE;
                st._sADDRESS = g.ADDRESS;
                st._sEMAIL = g.EMAIL;
                st._sbatchname = g.BATCH_CODE;
                st._sbatchsession = g.BATCH_SESSION;

                obj.Add(st);
            }

            return obj;
        }

        public List<labModel> _sellabs()
        {
            List<labModel> obj_labs = new List<labModel>();

            var sellabs = (from x in db.Lab_TB where x.STATUS == true select x).OrderByDescending(m => m.ID);
            foreach (var get in sellabs)
            {
                labModel l = new labModel();
                l.labId = get.ID;
                l.labName = get.Lab_Name;
                l.labStatus = (bool)get.STATUS;

                obj_labs.Add(l);
            }

            return obj_labs;

        }

        public List<labModel> _selTimetable()
        {
            List<labModel> obj_time = new List<labModel>();

            var seltime = from x in db.Lab_Time_TB
                          join b in db.Batch_TB on x.Batch_ID equals b.ID
                          join l in db.Lab_TB on x.Lab_ID equals l.ID
                          join u in db.User_TB on b.USERS_ID equals u.ID
                          join d in db.Dep_TB on u.Dep_ID equals d.ID
                          
                          where l.STATUS == true
                          select new
                          {
                              x.ID,
                              u.NAME,
                              d.Dep_Name,
                              d.Role_Dep_Name,
                              l.Lab_Name,
                              x.Lab_Timming,
                              x.Lab_Days,
                              b.BATCH_CODE
                              
                          };
            foreach (var get in seltime)
            {
                labModel lt = new labModel();

                lt.ltId = get.ID;
                lt.ltUsername = get.NAME;
                lt.ltdep = get.Dep_Name;
                lt.ltrole = get.Role_Dep_Name;
                lt.ltlabname = get.Lab_Name;
                lt.lttime = get.Lab_Timming;
                lt.ltdays = get.Lab_Days;
                lt.ltbatch = get.BATCH_CODE;

                obj_time.Add(lt);
            }
            return obj_time;
        }


        public List<comp> _selComplaints()
        {
            List<comp> obj_com = new List<comp>();
            var selcom = (from x in db.Complaint_TB
                          join u in db.User_TB on x.Users_ID equals u.ID
                          join d in db.Dep_TB on u.Dep_ID equals d.ID
                          join m in db.User_TB on x.Users_ID equals m.ID
                          join md in db.Dep_TB on u.Dep_ID equals md.ID
                          select new
                          {
                              x.ID,
                              user = u.NAME,
                              d.Dep_Name,
                              d.Role_Dep_Name,
                              x.ComplainName,
                              x.Decription,
                              x.Days_Of_Fix,
                              x.Date_Of_Complaint,
                              md_name = m.NAME,
                              md_dep = md.Dep_Name,
                              md_role = md.Role_Dep_Name,
                              x.MODIFIED_DATE,
                              x.STATUS
                          }).OrderByDescending(m => m.ID);

            foreach (var get in selcom)
            {
                comp c = new comp();

                c.comId = get.ID;
                c.comUsername = get.user;
                c.comUserdep = get.Dep_Name;
                c.com_User_dep_role = get.Role_Dep_Name;
                c.comName = get.ComplainName;
                c.comDes = get.Decription;
                c.comDay2fix = (int)get.Days_Of_Fix;
                c.comDate = (DateTime)get.Date_Of_Complaint;
                c.comStatus = get.STATUS;
                c.commodifyby = get.md_name;
                c.commodifybydep = get.md_dep;
                c.commodifybyrole = get.md_role;
                c.commodifyDate = (DateTime)get.MODIFIED_DATE;
                obj_com.Add(c);
            }
            return obj_com;

        }


        public List<Dep> _Allsel(string s, string ss)
        {
            if (ss.Equals("d"))
            {
                List<Dep> obj_Dep = new List<Dep>();

                var sel = (from x in db.Dep_TB
                           where SqlMethods.Like(x.Dep_Name, "%" + s + "%")
                           select x).OrderByDescending(m => m.ID);
                foreach (var d in sel)
                {
                    Dep dd = new Dep();
                    dd.Dep_ID = d.ID;
                    dd.Dep_name = d.Dep_Name;
                    dd.Dep_role = d.Role_Dep_Name;

                    obj_Dep.Add(dd);
                }
                return obj_Dep;
            }
            return null;

        }

   
        ///////////////////////end./////.............................
    }
}