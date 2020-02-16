using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stomatology.Data
{
    public class User:IdentityUser
    {
        [Required(ErrorMessage ="Полето е задължително")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Полето е задължително")]
        public string EGN { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public override string PhoneNumber{ get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
