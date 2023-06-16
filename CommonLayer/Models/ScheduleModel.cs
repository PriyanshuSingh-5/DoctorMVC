using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace CommonLayer.Models
{
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
	    public TimeSpan ScheduleTime { get; set; }
	    public string Location { get; set; }
	    public int DoctorID { get; set; }
    }
}
