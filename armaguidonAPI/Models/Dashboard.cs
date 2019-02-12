using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace armaguidonAPI.Models
{
    public class Dashboard
    {
        public int DashboardId { get; set; }
        [Required]
        public int UserId { get; set; }
        
        public User User { get; set; }


    }
}