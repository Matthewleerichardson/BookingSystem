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
            if (context.Staffs.Any())
            {
                return;   // DB has been seeded
            }

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

            var customers = new Customer[]
            {
            new Customer{FirstName="Joe",LastName="Gatto",Telephone="07580043213"},
            new Customer{FirstName="Sal",LastName="Vulcano",Telephone="0758243454"},
            new Customer{FirstName="James",LastName="Murray",Telephone="07580043290"},
            new Customer{FirstName="Brian",LastName="Quinn",Telephone="075800432800"},
            new Customer{FirstName="Leslie",LastName="Knope",Telephone="0758004313"},
            new Customer{FirstName="Sharon",LastName="Bombay",Telephone="075823454"},
            new Customer{FirstName="Leo",LastName="Raymond",Telephone="0750043290"},
            new Customer{FirstName="Tray",LastName="Puerto",Telephone="07500432810"}

            };
            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();


            var appointments = new Appointment[]
            {
            new Appointment{CustomerID=1,StaffID=1,AppointmentDate=DateTime.Parse("20/07/2017")},
            new Appointment{CustomerID=2,StaffID=2,AppointmentDate=DateTime.Parse("20/05/2017")},
            new Appointment{CustomerID=3,StaffID=3,AppointmentDate=DateTime.Parse("20/04/2017")},
            new Appointment{CustomerID=4,StaffID=4,AppointmentDate=DateTime.Parse("20/03/2017")},
            new Appointment{CustomerID=5,StaffID=5,AppointmentDate=DateTime.Parse("20/02/2017")},
            new Appointment{CustomerID=6,StaffID=6,AppointmentDate=DateTime.Parse("20/09/2017")},
            new Appointment{CustomerID=7,StaffID=7,AppointmentDate=DateTime.Parse("20/08/2017")},
            new Appointment{CustomerID=8,StaffID=8,AppointmentDate=DateTime.Parse("20/06/2017")}

            };
            foreach (Appointment c in appointments)
            {
                context.Appointments.Add(c);
            }
            context.SaveChanges();
        }
    }
}