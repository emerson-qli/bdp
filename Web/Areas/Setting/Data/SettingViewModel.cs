using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.Setting.Data {
    public class SettingViewModel : BaseViewModel {

        public List<Domain.Models.DocumentGroup> DocumentGroups {
            get;
            set;
        }

        public Domain.Models.DocumentGroup DocumentGroup {
            get;
            set;
        }

        public Domain.Models.AuditAuditor AuditAuditor {
            get;
            set;
        }

        public List <Domain.Models.AuditAuditor> AuditAuditors {
            get;
            set;
        }

        public List<Domain.Models.CompetencyType> CompetencyTypes {
            get;
            set;
        }

        public Domain.Models.CompetencyType CompetencyType {
            get;
            set;
        }


        public List<Domain.Models.Rating> Ratings {
            get;
            set;
        }

        public Domain.Models.Rating Rating {
            get;
            set;
        }


        public List<Domain.Models.IssueCategory> IssueCategories {
            get;
            set;
        }

        public Domain.Models.IssueCategory IssueCategory {
            get;
            set;
        }

        public List<Domain.Models.AuditCategory> AuditCategories {
            get;
            set;
        }

        public Domain.Models.AuditCategory AuditCategory {
            get;
            set;
        }


        public List<Domain.Models.DocumentCategory> DocumentCategories {
            get;
            set;
        }

        public Domain.Models.DocumentCategory DocumentCategory {
            get;
            set;
        }


        public List<Domain.Models.ApprovingAuthority> ApprovingAuthorities {
            get;
            set;
        }

        public Domain.Models.ApprovingAuthority ApprovingAuthority {
            get;
            set;
        }


        public List<Domain.Models.Reviewer> Reviewers {
            get;
            set;
        }

        public Domain.Models.Reviewer Reviewer {
            get;
            set;
        }


        public List<Domain.Models.ApprovingAuthorityMember> ApprovingAuthorityMembers {
            get;
            set;
        }

        public Domain.Models.ApprovingAuthorityMember ApprovingAuthorityMember {
            get;
            set;
        }


        public List<Domain.Models.ReviewerMember> ReviewerMembers {
            get;
            set;
        }

        public Domain.Models.ReviewerMember ReviewerMember {
            get;
            set;
        }


        public List<Domain.Models.DocumentQualification> DocumentQualifications {
            get;
            set;
        }

        public Domain.Models.DocumentQualification DocumentQualification {
            get;
            set;
        }


        public List<Domain.Models.DocumentSection> DocumentSections {
            get;
            set;
        }

        public Domain.Models.DocumentSection DocumentSection {
            get;
            set;
        }

        public Domain.Models.DocumentClassification DocumentClassification {
            get;
            set;
        }

        public List<Domain.Models.DocumentClassification> DocumentClassifications {
            get;
            set;
        }
        public Domain.Models.BusinessRiskType BusinessRiskType {
            get;
            set;
        }

        public List<Domain.Models.BusinessRiskType> BusinessRiskTypes {
            get;
            set;
        }


        public Domain.Models.IssueType IssueType {
            get;
            set;
        }

        public List<Domain.Models.IssueType> IssueTypes {
            get;
            set;
        }

        public Domain.Models.Setting Setting {
            get;
            set;
        }

        public List<Domain.Models.Setting> Settings {
            get;
            set;
        }


    }
}