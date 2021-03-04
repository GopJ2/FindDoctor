using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindDoc.Data.Entity.Appointments
{
    public class Appointment
    {
        public string Id { get; set; }

        public bool IsApprovedByDoctor { get; set; }

        public string Text { get; set; }

        public DateTime AppointmentDate { get; set; }

        public bool Completed { get; set; }

        public string DoctorId { get; set; }

        public string PatientId { get; set; }
    }
}
