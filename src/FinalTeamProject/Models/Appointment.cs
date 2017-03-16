using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalTeamProject.Models
{
    public class Appointment
    {

        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }


       //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
    }
}
