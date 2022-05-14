using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_PROJECT_e_Adminstrator.Models;
using System.Transactions;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class StudentMethos
    {
        e_AdminstratorEntities db = new e_AdminstratorEntities();

        public int insert(Student u, DateTime dob,int id)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                   
                        Sudent_TB uu = new Sudent_TB();
                        uu.NAME = u._sname;
                        uu.FATHER_NAME = u._sFATHER_NAME;
                        uu.CNIC = u._sCNIC;
                        uu.DOB = dob;
                        uu.PHONE = u._sPHONE;
                        uu.ADDRESS = u._sADDRESS;
                        uu.EMAIL = u._sEMAIL;
                        uu.PASSWORD = u._sPASSWORD;
                        uu.BATCH_ID = id;
                        uu.STATUS = true;

                        db.Sudent_TB.Add(uu);
                        db.SaveChanges();

                        ts.Complete();
                    
                    return 1;

                }
                catch
                {
                    return 0;
                    ts.Dispose();
                }
            }
        }

        public int delete(int i) 
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Sudent_TB s = db.Sudent_TB.Find(i);
                    s.STATUS = false;
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
        ///////////////////END..............................
    }
}