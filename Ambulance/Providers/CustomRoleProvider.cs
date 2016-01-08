using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Security.Cryptography;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using Ambulance.Models; 

namespace Ambulance.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            using (ambulanceEntities _db = new ambulanceEntities())
            {
                try
                {
                    // Получаем пользователя
                    ambulance_user user = (from u in _db.ambulance_user
                                 where u.login == login
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        role userRole = _db.role.Find(user.role_id);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.role_name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }
        public override void CreateRole(string roleName)
        {
            Role newRole = new Role() { role_name = roleName };
            UserContext db = new UserContext();
            db.Roles.Add(newRole);
            db.SaveChanges();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (ambulanceEntities _db = new ambulanceEntities())
            {
                try
                {
                    // Получаем пользователя
                    ambulance_user user = (from u in _db.ambulance_user
                                 where u.login == username
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        role userRole = _db.role.Find(user.role_id);

                        //сравниваем
                        if (userRole != null && userRole.role_name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public override string[] GetUsersInRole(string roleName)
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