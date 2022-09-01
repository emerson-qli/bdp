using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationCompliance : BaseModel<OrganizationComplianceState> {

        public Guid OrganizationId {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }

        public DateTime IssuedDate {
            get;
            set;
        }

        public DateTime ExpirationDate {
            get;
            set;
        }

        public string DocumentTypeName {
            get;
            set;
        }

        public Guid DocumentTypeId {
            get;
            set;
        }

        public string IssuingAuthority {
            get;
            set;
        }

        public string Category {
            get;
            set;
        }

        public string ResponsibleDepartmentName {
            get;
            set;
        }

        public Guid ResponsibleDepartmentId {
            get;
            set;
        }

        public List<OrganizationComplianceAccessibleDepartment> AccessibleDepartments {
            get;
            set;
        }

        public string SubsidiaryName {
            get;
            set;
        }

        public Guid SubsidiaryId {
            get;
            set;
        }

        public string ObligationOriginalFileName {
            get;
            set;
        }

        public string ObligationUniqueFileName {
            get;
            set;
        }

    }

    public enum OrganizationComplianceState {
        Active,
        Inactive
    }
}
