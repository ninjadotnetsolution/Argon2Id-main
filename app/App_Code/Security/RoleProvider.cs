using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Web;
using System.Web.Security;
using Argon2Id.Data;

namespace Argon2Id.Security
{
    public partial class ApplicationRoleProvider : ApplicationRoleProviderBase
    {
    }

    public enum RoleProviderSqlStatement
    {

        AddUserToRole,

        CreateRole,

        DeleteRole,

        DeleteRoleUsers,

        GetAllRoles,

        GetRolesForUser,

        GetUsersInRole,

        IsUserInRole,

        RemoveUserFromRole,

        RoleExists,

        FindUsersInRole,
    }

    public class ApplicationRoleProviderBase : RoleProvider
    {

        protected static SortedDictionary<RoleProviderSqlStatement, string> Statements = new SortedDictionary<RoleProviderSqlStatement, string>();

        private ConnectionStringSettings _connectionStringSettings;

        private bool _writeExceptionsToEventLog;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _applicationName;

        static ApplicationRoleProviderBase()
        {
            Statements[RoleProviderSqlStatement.AddUserToRole] = "\r\ninsert into UserRole(UserId, RoleId) \r\nvalues (\r\n     (select Id from User where User_Name=@UserName) \r\n    ,(select Id from Role where Name=@RoleName)\r\n    \r\n)";
            Statements[RoleProviderSqlStatement.CreateRole] = "insert into Role (Name) values (@RoleName)";
            Statements[RoleProviderSqlStatement.DeleteRole] = "delete from Role where Name = @RoleName";
            Statements[RoleProviderSqlStatement.DeleteRoleUsers] = "delete from UserRole where RoleId in (select Id from Role where Name = @RoleName)";
            Statements[RoleProviderSqlStatement.GetAllRoles] = "select Name RoleName from Role";
            Statements[RoleProviderSqlStatement.GetRolesForUser] = "\r\nselect Roles.Name RoleName from Role Roles \r\ninner join UserRole UserRoles on Roles.Id = UserRoles.RoleId \r\ninner join User Users on Users.Id = UserRoles.UserId\r\nwhere Users.User_Name = @UserName";
            Statements[RoleProviderSqlStatement.GetUsersInRole] = "select User_Name UserName from User where Id in (select UserId from UserRole where RoleId in (select Id from Role where Name = @RoleName))";
            Statements[RoleProviderSqlStatement.IsUserInRole] = "\r\nselect count(*) from UserRole\r\nwhere\r\n    UserId in (select Id from User where User_Name = @UserName) and \r\n    RoleId in (select Id from Role where Name = @RoleName)";
            Statements[RoleProviderSqlStatement.RemoveUserFromRole] = "\r\ndelete from UserRole\r\nwhere\r\n   UserId in (select Id from User where User_Name = @UserName) and\r\n   RoleId in (select Id from Role where Name = @RoleName)";
            Statements[RoleProviderSqlStatement.RoleExists] = "select count(*) from Role where Name = @RoleName";
            Statements[RoleProviderSqlStatement.FindUsersInRole] = "\r\nselect Users.User_Name UserName from User Users\r\ninner join UserRole UserRoles on Users.Id= UserRoles.UserId \r\ninner join Role Roles on UserRoles.RoleId = Roles.Id\r\nwhere \r\n\tUsers.User_Name like @UserName and \r\n\tRoles.Name = @RoleName";
        }

        public virtual ConnectionStringSettings ConnectionStringSettings
        {
            get
            {
                return _connectionStringSettings;
            }
        }

        public bool WriteExceptionsToEventLog
        {
            get
            {
                return _writeExceptionsToEventLog;
            }
        }

        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }

        protected virtual SqlStatement CreateSqlStatement(RoleProviderSqlStatement command)
        {
            var sql = new SqlText(Statements[command], ConnectionStringSettings.Name);
            sql.Command.CommandText = sql.Command.CommandText.Replace("@", sql.ParameterMarker);
            if (sql.Command.CommandText.Contains((sql.ParameterMarker + "ApplicationName")))
                sql.AssignParameter("ApplicationName", ApplicationName);
            sql.Name = ("Argon2Id Application Role Provider - " + command.ToString());
            sql.WriteExceptionsToEventLog = WriteExceptionsToEventLog;
            return sql;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            if (string.IsNullOrEmpty(name))
                name = "Argon2IdApplicationRoleProvider";
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Argon2Id application role provider");
            }
            base.Initialize(name, config);
            _applicationName = config["applicationName"];
            if (string.IsNullOrEmpty(_applicationName))
                _applicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            _writeExceptionsToEventLog = "true".Equals(config["writeExceptionsToEventLog"], StringComparison.CurrentCulture);
            _connectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if ((_connectionStringSettings == null) || string.IsNullOrEmpty(_connectionStringSettings.ConnectionString))
                throw new ProviderException("Connection string cannot be blank.");
        }

        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            foreach (var rolename in rolenames)
                if (!RoleExists(rolename))
                    throw new ProviderException(string.Format("Role name '{0}' not found.", rolename));
            foreach (var username in usernames)
            {
                if (username.Contains(","))
                    throw new ArgumentException("User names cannot contain commas.");
                foreach (var rolename in rolenames)
                    if (IsUserInRole(username, rolename))
                        throw new ProviderException(string.Format("User '{0}' is already in role '{1}'.", username, rolename));
            }
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.AddUserToRole))
                foreach (var username in usernames)
                {
                    ForgetUserRoles(username);
                    foreach (var rolename in rolenames)
                    {
                        sql.AssignParameter("UserName", username);
                        sql.AssignParameter("RoleName", rolename);
                        sql.ExecuteNonQuery();
                    }
                }
        }

        public override void CreateRole(string rolename)
        {
            if (rolename.Contains(","))
                throw new ArgumentException("Role names cannot contain commas.");
            if (RoleExists(rolename))
                throw new ProviderException("Role already exists.");
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.CreateRole))
            {
                sql.AssignParameter("RoleName", rolename);
                sql.ExecuteNonQuery();
            }
        }

        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            if (!RoleExists(rolename))
                throw new ProviderException("Role does not exist.");
            if (throwOnPopulatedRole && (GetUsersInRole(rolename).Length > 0))
                throw new ProviderException("Cannot delete a pouplated role.");
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.DeleteRole))
            {
                using (var sql2 = CreateSqlStatement(RoleProviderSqlStatement.DeleteRoleUsers))
                {
                    sql2.AssignParameter("RoleName", rolename);
                    sql2.ExecuteNonQuery();
                }
                sql.AssignParameter("RoleName", rolename);
                sql.ExecuteNonQuery();
            }
            return true;
        }

        public override string[] GetAllRoles()
        {
            var roles = new List<string>();
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.GetAllRoles))
                while (sql.Read())
                    roles.Add(Convert.ToString(sql["RoleName"]));
            return roles.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = null;
            var userRolesKey = string.Format("ApplicationRoleProvider_{0}_Roles", username);
            var contextIsAvailable = (HttpContext.Current != null);
            if (contextIsAvailable)
                roles = ((List<string>)(HttpContext.Current.Items[userRolesKey]));
            if (roles == null)
            {
                roles = new List<string>();
                using (var sql = CreateSqlStatement(RoleProviderSqlStatement.GetRolesForUser))
                {
                    sql.AssignParameter("UserName", username);
                    while (sql.Read())
                        roles.Add(Convert.ToString(sql["RoleName"]));
                    if (contextIsAvailable)
                        HttpContext.Current.Items[userRolesKey] = roles;
                }
            }
            return roles.ToArray();
        }

        public virtual void ForgetUserRoles(string username)
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Items.Remove(string.Format("ApplicationRoleProvider_{0}_Roles", username));
        }

        public override string[] GetUsersInRole(string rolename)
        {
            var users = new List<string>();
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.GetUsersInRole))
            {
                sql.AssignParameter("RoleName", rolename);
                while (sql.Read())
                    users.Add(Convert.ToString(sql["UserName"]));
            }
            return users.ToArray();
        }

        public override bool IsUserInRole(string username, string rolename)
        {
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.IsUserInRole))
            {
                sql.AssignParameter("UserName", username);
                sql.AssignParameter("RoleName", rolename);
                return (Convert.ToInt32(sql.ExecuteScalar()) > 0);
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            foreach (var rolename in rolenames)
                if (!RoleExists(rolename))
                    throw new ProviderException(string.Format("Role '{0}' not found.", rolename));
            foreach (var username in usernames)
                foreach (var rolename in rolenames)
                    if (!IsUserInRole(username, rolename))
                        throw new ProviderException(string.Format("User '{0}' is not in role '{1}'.", username, rolename));
            foreach (var username in usernames)
            {
                ForgetUserRoles(username);
                foreach (var rolename in rolenames)
                {
                    using (var sql = CreateSqlStatement(RoleProviderSqlStatement.RemoveUserFromRole))
                    {
                        sql.AssignParameter("UserName", username);
                        sql.AssignParameter("RoleName", rolename);
                        sql.ExecuteNonQuery();
                    }
                }
            }
        }

        public override bool RoleExists(string rolename)
        {
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.RoleExists))
            {
                sql.AssignParameter("RoleName", rolename);
                return (Convert.ToInt32(sql.ExecuteScalar()) > 0);
            }
        }

        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            var users = new List<string>();
            using (var sql = CreateSqlStatement(RoleProviderSqlStatement.FindUsersInRole))
            {
                sql.AssignParameter("UserName", usernameToMatch);
                sql.AssignParameter("RoleName", rolename);
                while (sql.Read())
                    users.Add(Convert.ToString(sql["UserName"]));
            }
            return users.ToArray();
        }
    }
}
