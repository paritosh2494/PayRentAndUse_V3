using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class UserRoleClass
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
        public DateTime DateAdded { get; set; }
    }
}