using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class UsersMethos
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public int insert(Users u, DateTime dob, string dname1, string drole1) 
        {
            using (TransactionScope ts = new TransactionScope()) 
            {
                try 
                {
                    int id = 0;
                    var sel = from x in db.Dep_TB where x.Dep_Name.Equals(dname1) && x.Role_Dep_Name.Equals(drole1) select x;
                    foreach (var g in sel) 
                    {
                        id = g.ID;
                    }
                    if (id > 0) 
                    {
                        User_TB uu = new User_TB();
                        uu.NAME = u.u_NAME;
                        uu.FATHER_NAME = u.u_FATHER_NAME;
                        uu.CNIC = u.u_CNIC;
                        uu.DOB = dob;
                        uu.PHONE = u.u_PHONE;
                        uu.ADDRESS = u.u_ADDRESS;
                        uu.EMAIL = u.u_EMAIL;
                        uu.PASSWORD = u.u_PASSWORD;
                        uu.Dep_ID = id;
                        uu.STATUS = true;

                        db.User_TB.Add(uu);
                        db.SaveChanges();

                        ts.Complete();
                    }
                    return 1;
                    
                }
                catch 
                {
                    return 0;                    
                }
            }
        }
      
        //public int edit() { }

        public int delete(int id)
        {
            using (TransactionScope ts = new TransactionScope()) 
            {
                try 
                {
                    User_TB u = db.User_TB.Find(id);
                    u.STATUS = false;
                    db.SaveChanges();
                    ts.Complete();
                    return 1;    
                }
                catch 
                {
                    ts.Dispose();
                    return 0;
                }
            }
        }


    }
}