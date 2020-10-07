using Cleverest.BLL.Interfaces;
using Cleverest.Common;
using Cleverest.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Cleverest.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private static IRoleLogic _roleLogic = Resolver.RoleLogic;
        public override string[] GetRolesForUser(string username)
        {
            var role = _roleLogic.GetRole(username);

            return new string[] { role };

        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return roleName == _roleLogic.GetRole(username);
            
        }


        #region NOT IMPLEMENTED
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



        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}