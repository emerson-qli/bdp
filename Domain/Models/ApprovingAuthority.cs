using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {


    public class ApprovingAuthority : BaseModel<ApprovingAuthorityState> {

        public string GroupName {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public List<ApprovingAuthorityMember> ApprovingAuthorityMembers {
            get;
            set;
        }

        public Guid LevelId {
            get;
            set;
        }

        public string LevelName {
            get;
            set;
        }

        public int LevelOrder {
            get;
            set;
        }

        public string DepartmentName {
            get;
            set;
        }

        public Guid DepartmentId {
            get;
            set;
        }

    }

    public enum ApprovingAuthorityState {
        Approver,
        Reviewer,
        Publisher
    }

}
