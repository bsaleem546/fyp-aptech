using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class Batch
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public int insert(batchModel b,int a) 
        {
            using (TransactionScope ts = new TransactionScope()) 
            {
                try 
                {
                    Batch_TB bt = new Batch_TB();
                    bt.BATCH_CODE = b._bname;
                    bt.BATCH_SESSION = b._bsession;
                    bt.CREATED_DATE = DateTime.Now;
                    bt.USERS_ID = a;
                    bt.STATUS = true;

                    db.Batch_TB.Add(bt);
                    db.SaveChanges();
                    ts.Complete();
                }
                catch 
                {
                    ts.Dispose();
                }
            }    
            return 0; 
        }

     //   public int edit() { return 0; }

        public int delete(int i) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Batch_TB b = db.Batch_TB.Find(i);
                    b.STATUS = false;
                    db.SaveChanges();
                    ts.Complete();
                }
                catch 
                {
                    ts.Dispose();
                }
            }
            return 0; 
        }

    }
}