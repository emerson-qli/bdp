using Service.Persistence;
using Service.RoleTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper {
    public class PermissionHelper {

        public bool GetPermission(Domain.Enums.ApplicationElement element) {
            return new RoleTemplateService().CheckIfRoleIsAllowed(UserSessionService<Domain.Models.User>.CurrentUser.Role.Id, element);
        }

    }
}
