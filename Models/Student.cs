using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_PROJECT_e_Adminstrator.Models
{
    public class Student
    {
        public int _sid { get; set; }

        [Required(ErrorMessage = "Name Feild Is Empty")]
        public string _sname { get; set; }

        [Required(ErrorMessage = "Father Name Feild Is Empty")]
        public string _sFATHER_NAME { get; set; }

        [Required(ErrorMessage = "CNIC Feild Is Empty")]
        [RegularExpression(@"^\(?([0-9]{5})\)?[-. ]?([0-9]{7})[-. ]?([0-9]{1})$", ErrorMessage = "Not a valid CNIC number")]
        public string _sCNIC { get; set; }

        [Required(ErrorMessage = "Date of brith Feild Is Empty")]
        public DateTime _sDOB { get; set; }

        [Required(ErrorMessage = "Phone Feild Is Empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Not a valid Phone number")]
        public string _sPHONE { get; set; }

        [Required(ErrorMessage = "Address Feild Is Empty")]
        public string _sADDRESS { get; set; }

        [Required(ErrorMessage = "Email Feild Is Empty")]
        [EmailAddress(ErrorMessage = "The email address is not valid")]
        public string _sEMAIL { get; set; }

        [Required(ErrorMessage = "Password Feild Is Empty")]
        public string _sPASSWORD { get; set; }

        public string _sbatchname { get; set; }
        public string _sbatchsession { get; set; }

        public string _susername { get; set; }
        public string _sdepname { get; set; }
        public string _sdeprolename { get; set; }


    }
}