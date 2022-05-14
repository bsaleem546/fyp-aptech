using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Functions
{
    public class comp
    {
        public int comId { get; set; }
        public string comUsername { get; set; }
        public string comUserdep { get; set; }
        public string com_User_dep_role { get; set; }
        public string comName { get; set; }
        public string comDes { get; set; }
        public int comDay2fix { get; set; }
        public DateTime comDate { get; set; }
        public string commodifyby { get; set; }
        public string commodifybydep { get; set; }
        public string commodifybyrole { get; set; }

        public DateTime commodifyDate { get; set; }

        public string comStatus { get; set; }


    }
}