using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;


namespace PayRentAndUse_V3
{
    public class WebRoleProvideClass : RoleProvider
    {      
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] role;
            string[] user = username.Split(',').ToArray();
            string usertype = user[1];
            if(usertype.Equals("Admin"))
            {
                role = new string[] { "admin" }; 
            }
            else if(usertype.Equals("User"))
            {
                role = new string[] { "user" };
            }
            else if(usertype.Equals("Vendor"))
            {
                role = new string[] { "vendor" };
            }
            else
            {
                throw new NotImplementedException();
            }
            //_context.UserRoles.
            return role;
            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}