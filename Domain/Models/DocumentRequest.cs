using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {

    public class DocumentRequest : BaseModel<DocumentRequestState> {

        public string DocumentNumber {
            get;
            set;
        }

        public string DCRN {
            get;
            set;
        }

        public Guid DocumentCategoryId {
            get;
            set;
        }

        public string DocumentCategoryName {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public Guid DocumentTypeId {
            get;
            set;
        }

        public string DocumentTypeName {
            get;
            set;
        }

        public string ReviewPeriod {
            get;
            set;
        } 

        public string Purpose {
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

        public string SectionId {
            get;
            set;
        }

        public string SectionName {
            get;
            set;
        }

        public Guid QualificationId {
            get;
            set;
        }

        public string QualificationName {
            get;
            set;
        }

        public Guid ReviewerSetId {
            get;
            set;
        }

        public string ReviewerSetName {
            get;
            set;
        }

        public Guid ApproverSetId {
            get;
            set;
        }

        public string ApproverSetName {
            get;
            set;
        }

        public Guid PublisherSetId {
            get;
            set;
        }

        public string PublisherSetName {
            get;
            set;
        }

        public List<DocumentRequestExternalDocument> DocumentRequestExternalDocuments {
            get;
            set;
        }

        public List<DocumentRequestSupportingDocument> SupportingDocuments {
            get;
            set;
        }

        public List<DocumentRequestComment> Comments {
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

        public Guid DepartmentId {
            get;
            set;
        }

        public string DepartmentName {
            get;
            set;
        }

        public Guid OrganizationManagementSystemId {
            get;
            set;
        }

        public string OrganizationManagementSystemName {
            get;
            set;
        }

        public string Content {
            get;
            set;
        }


        public string GeneralStatusDescription {
            get;
            set;
        }

        public string DocumentControlNumber {
            get;
            set;
        }

        public string AccessLevelName {
            get;
            set;
        }

        public Guid AccessLevelId {
            get;
            set;
        }

        public List<DocumentRequestForm> Forms {
            get;
            set;
        }

        public string UniqueFileName {
            get;
            set;
        }

        public string OriginalFileName {
            get;
            set;
        }

        public int RevisionNo {
            get;
            set;
        }

    }

    public enum DocumentReviewPeriod {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    public enum DocumentRequestState {
        Draft,
        Submit,
        InProcess,
        Publish,
        Cascaded,
        Obsolete,
        DraftRevision,
        SubmitRevision,
        Revised,
        DraftObsoletion,
        SubmitObsoletion
    }
}
