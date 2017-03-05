using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FinalTeamProject.Data;

namespace FinalTeamProject.Migrations
{
    [DbContext(typeof(BookingContext))]
    partial class BookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FinalTeamProject.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AppointmentDate");

                    b.Property<int>("CustomerID");

                    b.Property<int>("StaffID");

                    b.HasKey("AppointmentID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StaffID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("FinalTeamProject.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FinalTeamProject.Models.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Telephone");

                    b.HasKey("ID");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("FinalTeamProject.Models.Appointment", b =>
                {
                    b.HasOne("FinalTeamProject.Models.Customer", "Customer")
                        .WithMany("Appointment")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FinalTeamProject.Models.Staff", "Staff")
                        .WithMany("Appointment")
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
