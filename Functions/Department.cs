using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class Department
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public int insert(Dep d) 
        {
            try 
            {
                using (TransactionScope ts = new TransactionScope()) 
                {
                    Dep_TB dd = new Dep_TB();
                    dd.Dep_Name = d.Dep_name;
                    dd.Role_Dep_Name = d.Dep_role;

                    db.Dep_TB.Add(dd);
                    db.SaveChanges();
                    ts.Complete();
                    return 1;
                
                }
            }
            catch 
            {
                return 0;
            }
        }


        public int edit(int id, Dep dd) 
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dep_TB d = db.Dep_TB.Find(id);
                    d.Dep_Name = dd.Dep_name;
                    d.Role_Dep_Name = dd.Dep_role;

                    db.SaveChanges();
                    ts.Complete();
                    return 1;
                }

            }
            catch
            {
                return 0;
            }
        }

        public int delete(int id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Dep_TB d = db.Dep_TB.Find(id);
                    db.Dep_TB.Attach(d);
                    db.Dep_TB.Remove(d);

                    db.SaveChanges();
                    ts.Complete();
                    return 1;

                }

            }
            catch
            {
                return 0;

            }
        
        }

        ////////////END
    }
}