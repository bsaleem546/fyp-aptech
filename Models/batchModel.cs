using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Models
{
    public class batchModel
    {
        public int _bid { get; set; }

        [Required(ErrorMessage = "Batch Name Feild Is Empty")]

        public string _bname { get; set; }

        [Required(ErrorMessage = "Batch Session Feild Is Empty")]

        public string _bsession { get; set; }

        public int _buserid { get; set; }

        public DateTime _bdate { get; set; }

        public string _busername { get; set; }

        public string _bdep { get; set; }

        public string _bdeprole { get; set; }
    }
}