using System;
using System.Collections.Generic;

namespace FinalTeamProject.Models
{
    public class Appointment
    {

        public int AppointmentID { get; set; }
        public int CustomerID { get; set; }
        public int StaffID { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
    }
}
