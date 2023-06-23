using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Argon2Id.Data;

namespace Argon2Id.Models
{
    public enum UserDataField
    {

        ID,

        ManagerID,

        ManagerLogin,

        ManagerBranchName,

        BranchID,

        BranchName,

        Login,

        Password,

        EMail,

        Description,

        PasswordQuestion,

        PasswordAnswer,

        IsApproved,

        LastActivityDate,

        LastLoginDate,

        LastPasswordChangedDate,

        CreationDate,

        IsLockedOut,

        LastLockedOutDate,

        FailedPasswordAttemptCount,

        FailedPasswordAttemptWindowStart,

        FailedPasswordAnswerAttemptCount,

        FailedPasswordAnswerAttemptWindowStart,

        EulaacceptedOn,

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

        Comment,

        OrganizationId,

        Roles,

        PasswordConfirmation,
    }

    public partial class UserModel : BusinessRulesObjectModel
    {

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _iD;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _managerID;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _managerLogin;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _managerBranchName;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _branchID;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _branchName;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _login;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _password;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _eMail;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _description;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _passwordQuestion;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _passwordAnswer;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool? _isApproved;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _lastActivityDate;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _lastLoginDate;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _lastPasswordChangedDate;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _creationDate;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool? _isLockedOut;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _lastLockedOutDate;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int? _failedPasswordAttemptCount;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _failedPasswordAttemptWindowStart;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int? _failedPasswordAnswerAttemptCount;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _failedPasswordAnswerAttemptWindowStart;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private DateTime? _eulaacceptedOn;

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

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _comment;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private System.Guid? _organizationId;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _roles;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private string _passwordConfirmation;

        public UserModel()
        {
        }

        public UserModel(BusinessRules r) :
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

        public System.Guid? ManagerID
        {
            get
            {
                return _managerID;
            }
            set
            {
                _managerID = value;
                UpdateFieldValue("ManagerID", value);
            }
        }

        public string ManagerLogin
        {
            get
            {
                return _managerLogin;
            }
            set
            {
                _managerLogin = value;
                UpdateFieldValue("ManagerLogin", value);
            }
        }

        public string ManagerBranchName
        {
            get
            {
                return _managerBranchName;
            }
            set
            {
                _managerBranchName = value;
                UpdateFieldValue("ManagerBranchName", value);
            }
        }

        public System.Guid? BranchID
        {
            get
            {
                return _branchID;
            }
            set
            {
                _branchID = value;
                UpdateFieldValue("BranchID", value);
            }
        }

        public string BranchName
        {
            get
            {
                return _branchName;
            }
            set
            {
                _branchName = value;
                UpdateFieldValue("BranchName", value);
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                UpdateFieldValue("Login", value);
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                UpdateFieldValue("Password", value);
            }
        }

        public string EMail
        {
            get
            {
                return _eMail;
            }
            set
            {
                _eMail = value;
                UpdateFieldValue("EMail", value);
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

        public string PasswordQuestion
        {
            get
            {
                return _passwordQuestion;
            }
            set
            {
                _passwordQuestion = value;
                UpdateFieldValue("PasswordQuestion", value);
            }
        }

        public string PasswordAnswer
        {
            get
            {
                return _passwordAnswer;
            }
            set
            {
                _passwordAnswer = value;
                UpdateFieldValue("PasswordAnswer", value);
            }
        }

        public bool? IsApproved
        {
            get
            {
                return _isApproved;
            }
            set
            {
                _isApproved = value;
                UpdateFieldValue("IsApproved", value);
            }
        }

        public DateTime? LastActivityDate
        {
            get
            {
                return _lastActivityDate;
            }
            set
            {
                _lastActivityDate = value;
                UpdateFieldValue("LastActivityDate", value);
            }
        }

        public DateTime? LastLoginDate
        {
            get
            {
                return _lastLoginDate;
            }
            set
            {
                _lastLoginDate = value;
                UpdateFieldValue("LastLoginDate", value);
            }
        }

        public DateTime? LastPasswordChangedDate
        {
            get
            {
                return _lastPasswordChangedDate;
            }
            set
            {
                _lastPasswordChangedDate = value;
                UpdateFieldValue("LastPasswordChangedDate", value);
            }
        }

        public DateTime? CreationDate
        {
            get
            {
                return _creationDate;
            }
            set
            {
                _creationDate = value;
                UpdateFieldValue("CreationDate", value);
            }
        }

        public bool? IsLockedOut
        {
            get
            {
                return _isLockedOut;
            }
            set
            {
                _isLockedOut = value;
                UpdateFieldValue("IsLockedOut", value);
            }
        }

        public DateTime? LastLockedOutDate
        {
            get
            {
                return _lastLockedOutDate;
            }
            set
            {
                _lastLockedOutDate = value;
                UpdateFieldValue("LastLockedOutDate", value);
            }
        }

        public int? FailedPasswordAttemptCount
        {
            get
            {
                return _failedPasswordAttemptCount;
            }
            set
            {
                _failedPasswordAttemptCount = value;
                UpdateFieldValue("FailedPasswordAttemptCount", value);
            }
        }

        public DateTime? FailedPasswordAttemptWindowStart
        {
            get
            {
                return _failedPasswordAttemptWindowStart;
            }
            set
            {
                _failedPasswordAttemptWindowStart = value;
                UpdateFieldValue("FailedPasswordAttemptWindowStart", value);
            }
        }

        public int? FailedPasswordAnswerAttemptCount
        {
            get
            {
                return _failedPasswordAnswerAttemptCount;
            }
            set
            {
                _failedPasswordAnswerAttemptCount = value;
                UpdateFieldValue("FailedPasswordAnswerAttemptCount", value);
            }
        }

        public DateTime? FailedPasswordAnswerAttemptWindowStart
        {
            get
            {
                return _failedPasswordAnswerAttemptWindowStart;
            }
            set
            {
                _failedPasswordAnswerAttemptWindowStart = value;
                UpdateFieldValue("FailedPasswordAnswerAttemptWindowStart", value);
            }
        }

        public DateTime? EulaacceptedOn
        {
            get
            {
                return _eulaacceptedOn;
            }
            set
            {
                _eulaacceptedOn = value;
                UpdateFieldValue("EulaacceptedOn", value);
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

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                UpdateFieldValue("Comment", value);
            }
        }

        public System.Guid? OrganizationId
        {
            get
            {
                return _organizationId;
            }
            set
            {
                _organizationId = value;
                UpdateFieldValue("OrganizationId", value);
            }
        }

        public string Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                UpdateFieldValue("Roles", value);
            }
        }

        public string PasswordConfirmation
        {
            get
            {
                return _passwordConfirmation;
            }
            set
            {
                _passwordConfirmation = value;
                UpdateFieldValue("PasswordConfirmation", value);
            }
        }

        public FieldValue this[UserDataField field]
        {
            get
            {
                return this[field.ToString()];
            }
        }
    }
}
