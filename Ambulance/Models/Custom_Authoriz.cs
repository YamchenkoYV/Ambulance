using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ambulance.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public int prof_id { get; set; }

        public int role_id { get; set; }
        public Role Role { get; set; } 
    }

    public class Role
    {
        public long role_id { get; set; }
        public string role_name { get; set; }
        public string role_password { get; set; }
    }
}
