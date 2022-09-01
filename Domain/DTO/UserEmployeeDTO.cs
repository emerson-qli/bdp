using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class UserEmployeeDTO {

        public Guid RoleId {
            get;
            set;
        }

        public Guid UserId {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string Email {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

        public string RoleName {
            get;
            set;
        }

        public Domain.Models.UserStatus UserStatus {
            get;
            set;
        }

        public DateTime? UserLastLogin {
            get;
            set;
        }

        public DateTime DateCreated {
            get;
            set;
        }


    }
}
