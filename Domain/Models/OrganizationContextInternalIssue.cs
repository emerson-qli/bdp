using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationContextInternalIssue : BaseModel<OrganizationContextInternalIssueState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public Guid IssueCategoryId {
            get;
            set;
        }

        public string IssueCategoryName {
            get;
            set;
        }

        public Guid RatingId {
            get;
            set;
        }

        public string RatingName {
            get;
            set;
        }

        public string RatingColor {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public Guid IssueTypeId {
            get;
            set;
        }

        public string IssueTypeName {
            get;
            set;
        }

        public Guid BusinessRiskTypeId {
            get;
            set;
        }

        public string BusinessRiskTypeName {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeName {
            get;
            set;
        }

    }

    public enum OrganizationContextInternalIssueState {
        Active,
        Inactive
    }
}
