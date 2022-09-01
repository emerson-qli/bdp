using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class Reviewer : BaseModel<ReviewerState> {

        public string GroupName {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public List<ReviewerMember> ReviewerMembers {
            get;
            set;
        }

    }

    public enum ReviewerState {
        Active,
        Inactive
    }
}
