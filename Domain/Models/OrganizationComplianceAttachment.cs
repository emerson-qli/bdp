using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class OrganizationComplianceAttachment : BaseModel<OrganizationComplianceAttachmentState> {


        public Guid OrganizationComplianceId {
            get;
            set;
        }

        public string OrginalFileName {
            get;
            set;
        }
        public string UniqueFileName {
            get;
            set;
        }

    }

    public enum OrganizationComplianceAttachmentState {
        Active,
        Inactive
    }
}
