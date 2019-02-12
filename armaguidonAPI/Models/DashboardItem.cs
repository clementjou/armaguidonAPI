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
        public int ItemId { get; set; }
        public string Type { get; set; }
        public string Config { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
    }
}