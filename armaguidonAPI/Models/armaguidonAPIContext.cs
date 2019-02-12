using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace armaguidonAPI.Models
{
    public class armaguidonAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public armaguidonAPIContext() : base("name=armaguidonAPIContext")
        {
        }

        public System.Data.Entity.DbSet<armaguidonAPI.Models.Dashboard> Dashboards { get; set; }

        public System.Data.Entity.DbSet<armaguidonAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<armaguidonAPI.Models.DashboardItem> DashboardItems { get; set; }
    }
}
