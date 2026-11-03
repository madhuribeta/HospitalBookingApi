using HospitalBookingApi.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HospitalBookingApi.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Clinics.Any()) return;

            Console.WriteLine("--- Seeding Data From DbInitializer ---");

            var user = new User { Name = "Test User", Email = "test@example.com" };
            context.Users.Add(user);
            context.SaveChanges();

            var clinics = new List<Clinic>
            {
                new Clinic { Name = "Government Hospital", Address = "Bhimavaram, Andhra Pradesh", Latitude = 16.5449, Longitude = 81.5212 },
                new Clinic { Name = "Sri Surya Hospital", Address = "Bhimavaram, Andhra Pradesh", Latitude = 16.5455, Longitude = 81.5230 },
                new Clinic { Name = "Lotus Hospital", Address = "Bhimavaram, Andhra Pradesh", Latitude = 16.5480, Longitude = 81.5185 },
                new Clinic { Name = "Apollo Clinic", Address = "Bhimavaram, Andhra Pradesh", Latitude = 16.5430, Longitude = 81.5250 },
                new Clinic { Name = "Care Hospital", Address = "Bhimavaram, Andhra Pradesh", Latitude = 16.5400, Longitude = 81.5200 }
            };

            context.Clinics.AddRange(clinics);
            context.SaveChanges();

            var doctors = new List<Doctor>
            {
                new Doctor { Name = "Dr. John Doe", Specialty = "Cardiology", Bio = "Experienced cardiologist with 15 years in practice.", ClinicId = clinics[0].Id },
                new Doctor { Name = "Dr. Jane Roe", Specialty = "Neurology", Bio = "Specializes in brain and nervous system disorders.", ClinicId = clinics[0].Id },
                new Doctor { Name = "Dr. Sam Smith", Specialty = "Orthopedics", Bio = "Expert in sports injuries and joint replacements.", ClinicId = clinics[1].Id },
                new Doctor { Name = "Dr. Emily Chen", Specialty = "Cardiology", Bio = "Heart failure specialist.", ClinicId = clinics[1].Id },
                new Doctor { Name = "Dr. Michael Brown", Specialty = "Pediatrics", Bio = "Child health expert.", ClinicId = clinics[2].Id },
                new Doctor { Name = "Dr. Sarah Wilson", Specialty = "Dermatology", Bio = "Skin disease specialist.", ClinicId = clinics[2].Id },
                new Doctor { Name = "Dr. David Lee", Specialty = "General Medicine", Bio = "Primary care physician.", ClinicId = clinics[3].Id },
                new Doctor { Name = "Dr. Lisa White", Specialty = "Gastroenterology", Bio = "Expert in digestive health.", ClinicId = clinics[4].Id }
            };

            context.Doctors.AddRange(doctors);
            context.SaveChanges();

            var slots = new List<AppointmentSlot>
            {
                new AppointmentSlot { DoctorId = doctors[0].Id, StartTime = DateTime.Today.AddHours(9), EndTime = DateTime.Today.AddHours(10), IsBooked = false },
                new AppointmentSlot { DoctorId = doctors[0].Id, StartTime = DateTime.Today.AddHours(11), EndTime = DateTime.Today.AddHours(12), IsBooked = false },
                new AppointmentSlot { DoctorId = doctors[1].Id, StartTime = DateTime.Today.AddHours(14), EndTime = DateTime.Today.AddHours(15), IsBooked = false }
            };

            context.AppointmentSlots.AddRange(slots);
            context.SaveChanges();
            
            Console.WriteLine("--- Seeding Complete ---");
        }
    }
}
