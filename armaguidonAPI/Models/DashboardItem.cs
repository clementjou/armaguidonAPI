using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace armaguidonAPI.Models
{
    public class DashboardItem
    {
        [Key]
        public int itemId { get; set; }
        public string type { get; set; }
        public string config { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}