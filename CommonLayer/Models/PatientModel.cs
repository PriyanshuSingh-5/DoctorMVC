using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class PatientModel
    {
        public int PatientID { get; set; }
        public DateTime DOB { get; set; }
	    public string Gender { get; set; }
	    public string BloodGroup { get; set; }
	    public string PatientImage { get; set; }
        public string HealthConcern { get; set; }
        public string MedicalHistory { get; set; }
        public string InsuranceProvider { get; set; }
        public int UserID { get; set; }
        public bool Istrash { get; set; }
         public DateTime CreatedAt { get; set; }
         public DateTime UpdatedAt { get; set; }
    }
}
