using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using Argon2Id.Data;
using Argon2Id.Models;

namespace Argon2Id.Rules
{
    public partial class OrganizationBusinessRules : SharedBusinessRules
    {

        /// <summary>This method will execute in any view after an action
        /// with a command name that matches "Insert".
        /// </summary>
        [Rule("r101")]
        public void r101Implementation(OrganizationModel instance)
        {
            var user = Membership.CreateUser(instance.OwnerEmail, instance.OwnerPassword, instance.OwnerEmail);
            SqlText.ExecuteNonQuery("UPDATE [User] SET OrganizationId = @q0 WHERE Id = @q1", instance.ID, user.ProviderUserKey);
            Roles.AddUserToRole(instance.OwnerEmail, "Owners");
        }
    }
}
