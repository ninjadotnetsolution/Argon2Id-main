using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using Argon2Id.Data;
using Argon2Id.Models;
using Argon2Id.Security;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Argon2Id.Rules
{
    public partial class UserBusinessRules : SharedBusinessRules
    {

        /// <summary>This method will execute in any view for an action
        /// with a command name that matches "Insert|Update".
        /// </summary>
        [Rule("r100")]
        public void r100Implementation(UserModel user)
        {
            if (user[UserDataField.Password].Modified && user.Password != user.PasswordConfirmation)
            {
                PreventDefault();
                Result.ShowAlert("Password and confirmation does not match");

            }
            else
            {
                ApplicationMembershipProviderBase.ValidateUserPassword(user.UserName, user.Password);
                user.Password = ApplicationMembershipProvider.EncodeUserPassword(user.Password);
                //if (!UserIsInRole("Administrators"))
                //    user.OrganizationID = OrganizationID;

            }
        }
    }
}
