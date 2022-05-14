using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Models
{
    public class Dep
    {
        public int Dep_ID { get; set; }

        [Required(ErrorMessage = "Department Name Feild Is Empty")]
        public string Dep_name { get; set; }

        [Required(ErrorMessage = "Department Role Feild Is Empty")]
        public string Dep_role { get; set; }
    }
}