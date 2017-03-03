using System;
using System.Collections.Generic;

namespace FinalTeamProject.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }

        public ICollection<Appointment> Appointment { get; set; }
    }
}
