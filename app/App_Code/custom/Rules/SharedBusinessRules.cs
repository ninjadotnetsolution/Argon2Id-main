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

namespace Argon2Id.Rules
{
    public partial class SharedBusinessRules : BusinessRules
    {
        public SharedBusinessRules() { }

        public int OrganizationID
        {
            get
            {
                //object result = SqlText.ExecuteScalar("SELECT OrganizationId FROM [User] WHERE Id = @q0", UserId);
                //return result is DBNull ? -1 : (int)result;
                return 1;
            }
        }

        protected override void EnumerateDynamicAccessControlRules(string controllerName)
        {
            base.EnumerateDynamicAccessControlRules(controllerName);
            if (!UserIsInRole("Administrators"))
            {
                RegisterAccessControlRule("OrganizationID", AccessPermission.Allow, OrganizationID);
                RegisterAccessControlRule("RoleID", AccessPermission.Deny, 1);
                if (!UserIsInRole("Owners"))
                    RegisterAccessControlRule("CreatedBy", AccessPermission.Allow, UserId);
            }
        }

        public override bool SupportsVirtualization(string controllerName)
        {
            if (ControllerName == "Users")
                return true;
            return base.SupportsVirtualization(controllerName);
        }

        protected override void VirtualizeController(string controllerName)
        {
            base.VirtualizeController(controllerName);
            if (!UserIsInRole("Administrators"))
            {
                if (controllerName == "Users" || controllerName == "Receipts")
                    NodeSet().SelectViews("grid1", "createForm1").SelectDataField("OrganizationID").Hide();

            }
            else
            {
                if (controllerName == "Users")
                {
                    NodeSet().SelectActionGroup("ag1").CreateAction("Custom", "Impersonate")
                        .SetHeaderText("Impersonate").Attr("cssClass", "material-icon-group-add");
                }
            }

        }

        [ControllerAction("Users", "Custom", "Impersonate")]
        public void HandleImpersonate()
        {
            var userToImpersonate = (string)SelectFieldValue("UserName");
            if (!String.IsNullOrEmpty(userToImpersonate) && !userToImpersonate.Equals("admin", StringComparison.InvariantCulture) && UserIsInRole("Administrators"))
            {
                var password = StringEncryptor.ToBase64String(DateTime.Now);
                Result.ExecuteOnClient(@"
                $app.login('" + userToImpersonate + @"', 'impersonate:" + password + @"', false, function(){
                    setTimeout(function(){
                        $app._navigated = true;
                        window.location.replace($app.touch.returnUrl() || __baseUrl);
                    });
                });");
            }
        }

    }
}