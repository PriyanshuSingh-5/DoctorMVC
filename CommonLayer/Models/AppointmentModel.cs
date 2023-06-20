using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
	    public string Concerns { get; set; }
        public DateTime Appointmentdate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsTrash { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int ScheduleID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
