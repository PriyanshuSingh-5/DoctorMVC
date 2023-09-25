using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="{0} should not be empty")]
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public long ContactNo { get; set; }
        public int RoleID { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
