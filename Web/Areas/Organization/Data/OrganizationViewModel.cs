using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.Organization.Data {
    public class OrganizationViewModel : BaseViewModel {


        public List<Domain.Models.Organization> Organizations {
            get;
            set;
        }

        public Domain.Models.Organization Organization {
            get;
            set;
        }

        public Domain.Models.OrganizationChart OrganizationChart {
            get;
            set;
        }

        public List<Domain.Models.OrganizationChart> OrganizationCharts {
            get;
            set;
        }

        public Domain.Models.OrganizationPolicy OrganizationPolicy {
            get;
            set;
        }

        public List<Domain.Models.OrganizationPolicy> OrganizationPolicies {
            get;
            set;
        }


        public List<Domain.Models.OrganizationManagementSystem> OrganizationManagementSystems {
            get;
            set;
        }

        public Domain.Models.OrganizationManagementSystem OrganizationManagementSystem {
            get;
            set;
        }


        public List<Domain.Models.OrganizationSubsidiary> OrganizationSubsidiaries {
            get;
            set;
        }

        public Domain.Models.OrganizationSubsidiary OrganizationSubsidiary {
            get;
            set;
        }


        public List<Domain.Models.OrganizationProduct> OrganizationProducts {
            get;
            set;
        }

        public Domain.Models.OrganizationProduct OrganizationProduct {
            get;
            set;
        }


        public List<Domain.Models.OrganizationService> OrganizationServices {
            get;
            set;
        }

        public Domain.Models.OrganizationService OrganizationService {
            get;
            set;
        }


        public List<Domain.Models.OrganizationVision> OrganizationVisions {
            get;
            set;
        }

        public Domain.Models.OrganizationVision OrganizationVision {
            get;
            set;
        }


        public List<Domain.Models.OrganizationValue> OrganizationValues {
            get;
            set;
        }

        public Domain.Models.OrganizationValue OrganizationValue {
            get;
            set;
        }


        public List<Domain.Models.OrganizationCompliance> OrganizationCompliances {
            get;
            set;
        }

        public Domain.Models.OrganizationCompliance OrganizationCompliance {
            get;
            set;
        }


        public List<Domain.Models.OrganizationComplianceCertificate> OrganizationComplianceCertificates {
            get;
            set;
        }

        public Domain.Models.OrganizationComplianceCertificate OrganizationComplianceCertificate {
            get;
            set;
        }


        public List<Domain.Models.OrganizationProcess> OrganizationProcesses {
            get;
            set;
        }

        public Domain.Models.OrganizationProcess OrganizationProcess {
            get;
            set;
        }

        public List<Domain.Models.OrganizationBusinessProcess> OrganizationBusinessProcesses {
            get;
            set;
        }

        public Domain.Models.OrganizationBusinessProcess OrganizationBusinessProcess {
            get;
            set;
        }


        public List<Domain.Models.OrganizationBusinessProcessStep> OrganizationBusinessProcessSteps {
            get;
            set;
        }

        public Domain.Models.OrganizationBusinessProcessStep OrganizationBusinessProcessStep {
            get;
            set;
        }


        public List<Domain.Models.OrganizationBusinessProcessInteractingDepartment> OrganizationBusinessProcessInteractingDepartments {
            get;
            set;
        }

        public Domain.Models.OrganizationBusinessProcessInteractingDepartment OrganizationBusinessProcessInteractingDepartment {
            get;
            set;
        }


        public List<Domain.Models.OrganizationBusinessProcessSubProcess> OrganizationBusinessProcessSubProcesses {
            get;
            set;
        }

        public Domain.Models.OrganizationBusinessProcessSubProcess OrganizationBusinessProcessSubProcess {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextSWOT> Strengths {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextSWOT> Weaknesses {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextSWOT> Opportunities {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextSWOT> Threats {
            get;
            set;
        }

        public Domain.Models.OrganizationContextSWOT SWOT {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Generals {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Politicals {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Economicals {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Socials {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Technologicals {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Ecologicals {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextPESTLE> Legals {
            get;
            set;
        }

        public Domain.Models.OrganizationContextPESTLE PESTLE {
            get;
            set;
        }

        public List<Domain.Models.IssueCategory> IssueCategories {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextInternalIssue> InternalIssues {
            get;
            set;
        }

        public List<Domain.Models.OrganizationContextExternalIssue> ExternalIssues {
            get;
            set;
        }
        public Domain.Models.OrganizationContextInternalIssue InternalIssue {
            get;
            set;
        }

        public Domain.Models.OrganizationContextExternalIssue ExternalIssue {
            get;
            set;
        }

        public string DeletePermission {
            get;
            set;
        }


    }
}