using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class labMethods
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public int insert(labModel lm) 
        {
            using (TransactionScope ts = new TransactionScope()) 
            {
                try 
                {
                    Lab_TB l = new Lab_TB();
                    l.Lab_Name = lm.labName;
                    l.STATUS = true;

                    db.Lab_TB.Add(l);
                    db.SaveChanges();

                    ts.Complete();

                    return 1;

                }
                catch 
                {
                    return 0;                
                }
            }

        }

        public int edit(labModel lm,int id) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Lab_TB l = db.Lab_TB.Find(id);
                    l.Lab_Name = lm.labName;
                    l.STATUS = true;

                  
                    db.SaveChanges();

                    ts.Complete();

                    return 1;

                }
                catch
                {
                    return 0;
                }
            }
        }

        public int delete(int id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Lab_TB l = db.Lab_TB.Find(id);
                    
                    l.STATUS = false;


                    db.SaveChanges();

                    ts.Complete();

                    return 1;

                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}