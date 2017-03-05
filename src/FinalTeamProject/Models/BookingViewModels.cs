using System;
using System.ComponentModel.DataAnnotations;

namespace FinalTeamProject.Models.BookigViewModels
{
    public class CustomerGroup
    {
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }

        public int CustomerCount { get; set; }
    }
}