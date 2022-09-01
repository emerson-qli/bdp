using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationComplianceCertificate : BaseModel<OrganizationComplianceCertificateState> {

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

        public Guid ManagementSystemId {
            get;
            set;
        }


        public string ManagementSystemType {
            get;
            set;
        }

        public string ManagementSystemVersion {
            get;
            set;
        }

        public string CertificateOriginalFileName {
            get;
            set;
        }

        public string CertificateUniqueFileName {
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

        public string Scope {
            get;
            set;
        }

    }

    public enum OrganizationComplianceCertificateState {
        Active,
        Inactive
    }
}
