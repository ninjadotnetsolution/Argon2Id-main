using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.Security;
using Argon2Id.Data;
using System.IO;
using System.Activities.Statements;

namespace Argon2Id.Services
{
    public partial class ApplicationServices
    {
        public override bool UserLogin(string username, string password, bool createPersistentCookie)
        {
            var userExists = false;
            using (var q = new SqlText("SELECT User_Name FROM [User] WHERE User_Name = @username"))
                if (q.Read(new { username }))
                    userExists = true;
            if (!userExists)
            {
                var email = "";
                using (var q = new SqlText("SELECT Email FROM Account WHERE Name = @username"))
                    if (q.Read(new { username }))
                        email = Convert.ToString(q["Email"]);
                if (!String.IsNullOrEmpty(email) && email == password)
                {
                    Membership.CreateUser(username, password);
                    System.Web.Security.Roles.AddUserToRole(username, "Users");

                }
            }

            if (Controller.UserIsInRole("Administrators") && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && password.StartsWith("impersonate:"))
            {
                try
                {
                    var info = StringEncryptor.FromBase64String(password.Substring("impersonate:".Length));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return base.UserLogin(username, password, createPersistentCookie);
        }

        public override void LoadContent(HttpRequest request, HttpResponse response, SortedDictionary<string, string> content)
        {
            if (request.Path.ToLower().StartsWith("/pages"))
            {
                var user = Membership.GetUser();
                if (user != null && user.Comment == "EULAAccepted")
                {
                    content["File"] = File.ReadAllText(HttpContext.Current.Server.MapPath("~/pages/eula.html"));
                }
            }
            if (!content.ContainsKey("File"))
                base.LoadContent(request, response, content);
        }

    }
}