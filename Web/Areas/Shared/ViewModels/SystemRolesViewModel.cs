using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Shared.ViewModels {
    public class SystemRolesIndexViewModel : BaseViewModel {
        public List<Domain.Models.Role> Roles {
            set;
            get;
        }
        public List<Role> Role { get; internal set; }
    }

    public class SystemRolesCreateViewModel {
        public Domain.Models.Role Role {
            set;
            get;
        }
    }

    public class SystemRolesEditViewModel {
        public Domain.Models.Role Role {
            set;
            get;
        }
    }

    public class SystemRolesViewViewModel : BaseViewModel {

        public Domain.Models.Role Role {
            set;
            get;
        }

        public Dictionary<string, Domain.Models.RoleTemplate> RoleTemplates { 
            get; 
            set; 
        }
    }

    public class SystemRolesGrantPermissionViewModel {

        public Domain.Models.RoleTemplate RoleTemplate {
            set;
            get;
        }
    }

    public class SystemRolesGrantPermissionsViewModel {
        public List<Domain.Models.RoleTemplate> RoleTemplates {
            set;
            get;
        }
    }

    public class SystemRolesRevokePermissionsViewModel {
        public List<Domain.Models.RoleTemplate> RevokePermissions {
            set;
            get;
        }
    }
}