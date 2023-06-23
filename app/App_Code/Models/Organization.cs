using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Argon2Id.Data;

namespace Argon2Id.Models
{
    public enum OrganizationDataField
    {

        ID,

        Name,

        OwnerEmail,

        OwnerPassword,

        OwnerPasswordConfirmation,
    }

    public partial class OrganizationModel : BusinessRulesObjectModel
    {

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _iD;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _name;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _ownerEmail;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _ownerPassword;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _ownerPasswordConfirmation;

        public OrganizationModel()
        {
        }

        public OrganizationModel(BusinessRules r) :
                base(r)
        {
        }

        public System.Guid? ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
                UpdateFieldValue("ID", value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                UpdateFieldValue("Name", value);
            }
        }

        public string OwnerEmail
        {
            get
            {
                return _ownerEmail;
            }
            set
            {
                _ownerEmail = value;
                UpdateFieldValue("OwnerEmail", value);
            }
        }

        public string OwnerPassword
        {
            get
            {
                return _ownerPassword;
            }
            set
            {
                _ownerPassword = value;
                UpdateFieldValue("OwnerPassword", value);
            }
        }

        public string OwnerPasswordConfirmation
        {
            get
            {
                return _ownerPasswordConfirmation;
            }
            set
            {
                _ownerPasswordConfirmation = value;
                UpdateFieldValue("OwnerPasswordConfirmation", value);
            }
        }

        public FieldValue this[OrganizationDataField field]
        {
            get
            {
                return this[field.ToString()];
            }
        }
    }
}
