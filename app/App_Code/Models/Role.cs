using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Argon2Id.Data;

namespace Argon2Id.Models
{
    public enum RoleDataField
    {

        ID,

        Name,

        Description,

        RowVersion,

        AppName,

        UserName,

        OriginalLogin,

        SuserSname,

        CreatedOn,

        CreatedBy,

        AccessedOn,

        AccessedBy,

        ModifiedOn,

        ModifiedBy,

        ValidFrom,

        ValidTo,
    }

    public partial class RoleModel : BusinessRulesObjectModel
    {

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _iD;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _name;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _description;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private byte[] _rowVersion;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _appName;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _userName;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _originalLogin;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _suserSname;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _createdOn;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _createdBy;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _accessedOn;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _accessedBy;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _modifiedOn;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _modifiedBy;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _validFrom;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _validTo;

        public RoleModel()
        {
        }

        public RoleModel(BusinessRules r) :
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

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                UpdateFieldValue("Description", value);
            }
        }

        public byte[] RowVersion
        {
            get
            {
                return _rowVersion;
            }
            set
            {
                _rowVersion = value;
                UpdateFieldValue("RowVersion", value);
            }
        }

        public string AppName
        {
            get
            {
                return _appName;
            }
            set
            {
                _appName = value;
                UpdateFieldValue("AppName", value);
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                UpdateFieldValue("UserName", value);
            }
        }

        public string OriginalLogin
        {
            get
            {
                return _originalLogin;
            }
            set
            {
                _originalLogin = value;
                UpdateFieldValue("OriginalLogin", value);
            }
        }

        public string SuserSname
        {
            get
            {
                return _suserSname;
            }
            set
            {
                _suserSname = value;
                UpdateFieldValue("SuserSname", value);
            }
        }

        public DateTime? CreatedOn
        {
            get
            {
                return _createdOn;
            }
            set
            {
                _createdOn = value;
                UpdateFieldValue("CreatedOn", value);
            }
        }

        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }
            set
            {
                _createdBy = value;
                UpdateFieldValue("CreatedBy", value);
            }
        }

        public DateTime? AccessedOn
        {
            get
            {
                return _accessedOn;
            }
            set
            {
                _accessedOn = value;
                UpdateFieldValue("AccessedOn", value);
            }
        }

        public string AccessedBy
        {
            get
            {
                return _accessedBy;
            }
            set
            {
                _accessedBy = value;
                UpdateFieldValue("AccessedBy", value);
            }
        }

        public DateTime? ModifiedOn
        {
            get
            {
                return _modifiedOn;
            }
            set
            {
                _modifiedOn = value;
                UpdateFieldValue("ModifiedOn", value);
            }
        }

        public string ModifiedBy
        {
            get
            {
                return _modifiedBy;
            }
            set
            {
                _modifiedBy = value;
                UpdateFieldValue("ModifiedBy", value);
            }
        }

        public DateTime? ValidFrom
        {
            get
            {
                return _validFrom;
            }
            set
            {
                _validFrom = value;
                UpdateFieldValue("ValidFrom", value);
            }
        }

        public DateTime? ValidTo
        {
            get
            {
                return _validTo;
            }
            set
            {
                _validTo = value;
                UpdateFieldValue("ValidTo", value);
            }
        }

        public FieldValue this[RoleDataField field]
        {
            get
            {
                return this[field.ToString()];
            }
        }
    }
}
