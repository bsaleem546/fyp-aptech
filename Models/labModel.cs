using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Models
{
    public class labModel
    {

        public int labId { get; set; }

        [Required(ErrorMessage = "Name Feild Is Empty")]
        public string labName { get; set; }
        public bool labStatus { get; set; }


        public int ltId { get; set; }
        public string ltUsername { get; set; }
        public string ltdep { get; set; }
        public string ltrole { get; set; }
        public string ltlabname { get; set; }
        public string lttime { get; set; }
        public string ltdays { get; set; }
        public string ltbatch { get; set; }

    }
}