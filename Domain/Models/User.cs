using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class User : BaseModel<UserStatus> {

        public string Username {
            set;
            get;
        }

        public string Password {
            set;
            get;
        }

        public Guid RoleId {
            set;
            get;
        }

        public string Fullname {
            get;
            set;
        } 


        public Role Role {
            set;
            get;
        }

        public DateTime? LastLogin {
            get;
            set;
        }

    }
    public enum UserStatus {
        InActive,
        Active
    }
}
