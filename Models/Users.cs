using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Models
{
    public class Users
    {

        public int u_id { get; set; }

        [Required(ErrorMessage = "Name Feild Is Empty")]
        public string u_NAME { get; set; }

        [Required(ErrorMessage = "Father Name Feild Is Empty")]
        public string u_FATHER_NAME { get; set; }

        [Required(ErrorMessage = "CNIC Feild Is Empty")]
        [RegularExpression(@"^\(?([0-9]{5})\)?[-. ]?([0-9]{7})[-. ]?([0-9]{1})$", ErrorMessage = "Not a valid CNIC number")]
        public string u_CNIC { get; set; }

        [Required(ErrorMessage = "Date of brith Feild Is Empty")]
        public DateTime u_DOB { get; set; }

        [Required(ErrorMessage = "Phone Feild Is Empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        public string u_PHONE { get; set; }

        [Required(ErrorMessage = "Address Feild Is Empty")]
        public string u_ADDRESS { get; set; }

        [Required(ErrorMessage = "Email Feild Is Empty")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string u_EMAIL { get; set; }

        [Required(ErrorMessage = "Password Feild Is Empty")]
        public string u_PASSWORD { get; set; }


        public int u_Dep_ID { get; set; }
        public string u_Dep_name { get; set; }
        public string u_Dep_role { get; set; }



        public int labId { get; set; }
        public string labName { get; set; }
        public bool labStatus { get; set; }


        public int comId { get; set; }
        public string comUsername { get; set; }
        public string comUserdep { get; set; }
        public string com_User_dep_role { get; set; }
        public string comName { get; set; }
        public string comDes { get; set; }
        public int comDay2fix { get; set; }
        public DateTime comDate { get; set; }
        public string comStatus { get; set; }


        public int ltId { get; set; }
        public string ltUsername { get; set; }
        public string ltdep { get; set; }
        public string ltrole { get; set; }
        public string ltlabname { get; set; }
        public string lttime { get; set; }
        public string ltdays { get; set; }

        


    }
}