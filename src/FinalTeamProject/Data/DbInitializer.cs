using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinalTeamProject.Data;

namespace FinalTeamProject.Models
{
    public static class DbInitializer
    {
        public static void Initialize(BookingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
            new Customer{FirstName="Joe",LastName="Gatto",Telephone="07580043213"},
            new Customer{FirstName="Sal",LastName="Vulcano",Telephone="0758243454"},
            new Customer{FirstName="James",LastName="Murray",Telephone="07580043290"},
            new Customer{FirstName="Brian",LastName="Quinn",Telephone="075800432800"},
            new Customer{FirstName="Leslie",LastName="Knope",Telephone="0758004313"},
            new Customer{FirstName="Sharon",LastName="Bombay",Telephone="075823454"},
            new Customer{FirstName="Leo",LastName="Raymond",Telephone="0750043290"},
            new Customer{FirstName="Tray",LastName="Puerto",Telephone="07500432800"}

            };
            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            {
            new Appointment{CustomerID=201,StaffID=101,AppointmentDate=DateTime.Parse("2005-09-01")},
            new Appointment{CustomerID=202,StaffID=102,AppointmentDate=DateTime.Parse("2005-09-02")},
            new Appointment{CustomerID=203,StaffID=103,AppointmentDate=DateTime.Parse("2005-09-04")},
            new Appointment{CustomerID=204,StaffID=104,AppointmentDate=DateTime.Parse("2005-09-06")},
            new Appointment{CustomerID=205,StaffID=105,AppointmentDate=DateTime.Parse("2005-09-01")},
            new Appointment{CustomerID=206,StaffID=106,AppointmentDate=DateTime.Parse("2005-09-02")},
            new Appointment{CustomerID=207,StaffID=107,AppointmentDate=DateTime.Parse("2005-09-04")},
            new Appointment{CustomerID=208,StaffID=108,AppointmentDate=DateTime.Parse("2005-09-06")}

            };
            foreach (Appointment c in appointments)
            {
                context.Appointments.Add(c);
            }
            context.SaveChanges();

            var staffs = new Staff[]
            {
            new Staff{FirstName="Mary",LastName="Jones",Telephone="0123456789"},
            new Staff{FirstName="John",LastName="Legend",Telephone="0123456776"},
            new Staff{FirstName="Benny",LastName="Curtis",Telephone="0123456712"},
            new Staff{FirstName="Lloyd",LastName="Wilkins",Telephone="0123456723"},
            new Staff{FirstName="Oliver",LastName="Smith",Telephone="0123456789"},
            new Staff{FirstName="Keith",LastName="Hurtz",Telephone="0123456776"},
            new Staff{FirstName="Fiona",LastName="Dobbs",Telephone="0123456712"},
            new Staff{FirstName="Kayla",LastName="Federico",Telephone="0123456723"}
            };
            foreach (Staff e in staffs)
            {
                context.Staffs.Add(e);
            }
            context.SaveChanges();
        }
    }
}