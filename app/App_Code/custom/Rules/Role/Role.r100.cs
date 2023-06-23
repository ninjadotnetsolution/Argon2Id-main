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
    public partial class RoleBusinessRules : Argon2Id.Rules.SharedBusinessRules
    {

        /// <summary>This method will execute in any view before an action
        /// with a command name that matches "Select".
        /// </summary>
        [Rule("r100")]
        public void r100Implementation(RoleModel instance)
        {
            if (!UserIsInRole("Administrators"))
            {
                throw new Exception("Not allowed.");
            }
        }
    }
}
