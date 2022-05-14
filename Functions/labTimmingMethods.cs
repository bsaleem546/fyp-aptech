using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class labTimmingMethods
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();
        public int insert(int b,int l,string lt,string ld) 
        {
            using (TransactionScope ts = new TransactionScope()) 
            {
                try 
                {
                    var s = from x in db.Lab_Time_TB 
                            where  x.Lab_ID == l && 
                            x.Lab_Timming.Equals(lt) && x.Lab_Days.Equals(ld) select x;
                    bool ck = false;
                    foreach (var g in s) 
                    {
                        ck = true;
                    }
                    if (ck == false) 
                    {
                        Lab_Time_TB ll = new Lab_Time_TB();
                        ll.Batch_ID = b;
                        ll.Lab_ID = l;
                        ll.Lab_Timming = lt;
                        ll.Lab_Days = ld;

                        db.Lab_Time_TB.Add(ll);
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

        public int edit(int id, int b, int l, string lt, string ld) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    var s = from x in db.Lab_Time_TB
                            where   x.Lab_ID == l &&
                            x.Lab_Timming.Equals(lt) && x.Lab_Days.Equals(ld)
                            select x;
                    bool ck = false;
                    foreach (var g in s)
                    {
                        ck = true;
                    }
                    if (ck == false)
                    {
                        Lab_Time_TB ll = db.Lab_Time_TB.Find(id);
                        ll.Batch_ID = b;
                        ll.Lab_ID = l;
                        ll.Lab_Timming = lt;
                        ll.Lab_Days = ld;

                        db.SaveChanges();
                        ts.Complete();
                        return 1;
                    }
                    else 
                    {
                        return 0;
                    }
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
                    Lab_Time_TB lt = db.Lab_Time_TB.Find(id);
                    db.Lab_Time_TB.Attach(lt);
                    db.Lab_Time_TB.Remove(lt);
                    db.SaveChanges();
                    ts.Complete();
                }
                catch 
                {
                
                }
            }
            return 0; 
        }

    }
}