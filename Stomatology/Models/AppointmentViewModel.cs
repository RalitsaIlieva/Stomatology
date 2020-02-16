using Stomatology.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Stomatology.Models
{
    public class AppointmentViewModel
    {

        public AppointmentViewModel()
        {
            Date = new DateTime();
           // Hour = new DateTime();
           // Description = null;
            User = new User();
        
        }
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Hour { get; set; }

        public string Description { get; set; }

        [Required]
        public User User { get; set; }

       // public List<SelectListItem> HoursAvailable { get; set; }



    }
}
