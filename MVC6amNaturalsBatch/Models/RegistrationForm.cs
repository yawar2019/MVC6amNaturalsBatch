using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC6amNaturalsBatch.Models
{
    
        public class RegistrationForm
        {
            [Required(ErrorMessage ="UserName is Required")]
            public string UserName { get; set; }

            public string Password { get; set; }

            [Compare("Password", ErrorMessage="Password and Confirm Password are not Same")]
            public string ConfirmPwd { get; set; }

            [DataType(DataType.EmailAddress, ErrorMessage="Email Id is not Invalid")]
            public string Email { get; set; }

            [Range(18, 60, ErrorMessage="18, 60 is only Valid")]
            public int age { get; set; }

            [StringLength(10, ErrorMessage="10 character as a address u can give")]
            public string Address { get; set; }
        }
    }
 