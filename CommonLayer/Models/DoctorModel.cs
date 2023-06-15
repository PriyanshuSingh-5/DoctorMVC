using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models
{
    public class DoctorModel
    {
        public int DoctorID { get; set; }
       public string DoctorImage { get; set; }
       public int Age { get; set; }
       public string Gender { get; set; }
       public string Qualification { get; set; }
       public double Experience { get; set; }
       public int UserID { get; set; }
       public int RoleID { get; set; }
       
        public DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
        public int CategoryID { get; set; }
    }
}
