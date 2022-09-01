using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.AuditManagement.Data {
    public class AuditManagementViewModel : BaseViewModel {

        public List<Domain.Models.ActionPlan> ActionPlans {
            get;
            set;
        }

        public Domain.Models.ActionPlan ActionPlan {
            get;
            set;
        }


        public List<Domain.Models.AnnualPlan> AnnualPlans {
            get;
            set;
        }

        public Domain.Models.AnnualPlan AnnualPlan {
            get;
            set;
        }


        public List<Domain.Models.AuditCalendar> AuditCalendars {
            get;
            set;
        }

        public Domain.Models.AuditCalendar AuditCalendar {
            get;
            set;
        }


        public List<Domain.Models.AuditTeam> AuditTeams {
            get;
            set;
        }

        public Domain.Models.AuditTeam AuditTeam {
            get;
            set;
        }

        public Domain.Models.AuditPlanAuditor AuditPlanAuditor {
            get;
            set;
        }

        public List<Domain.Models.AuditPlanAuditor> AuditPlanAuditors {
            get;
            set;
        }

        public List<Domain.Models.AuditUniverse> AuditUniverses {
            get;
            set;
        }

        public Domain.Models.AuditUniverse AuditUniverse {
            get;
            set;
        }

        public List<Domain.Models.Audit> InternalAudits {
            get;
            set;
        }

        public Domain.Models.Audit InternalAudit {
            get;
            set;
        }

        public List<Domain.Models.AuditOrganizationBusinessProcess> AuditOrganizationBusinessProcesses {
            get;
            set;
        }

        public Domain.Models.AuditOrganizationBusinessProcess AuditOrganizationBusinessProcess {
            get;
            set;
        }

        public List<Domain.Models.IssueTracker> IssueTrackers {
            get;
            set;
        }

        public Domain.Models.IssueTracker IssueTracker {
            get;
            set;
        }

        public List<Domain.Models.ISMSRiskRegister> ISMSRiskRegisters {
            get;
            set;
        }

        public Domain.Models.ISMSRiskRegister ISMSRiskRegister {
            get;
            set;
        }


        public List<Domain.Models.ProcessRiskRegister> ProcessRiskRegisters {
            get;
            set;
        }

        public Domain.Models.ProcessRiskRegister ProcessRiskRegister {
            get;
            set;
        }


        public List<Domain.Models.RiskAndOpportunityRegister> RiskAndOpportunityRegisters {
            get;
            set;
        }

        public Domain.Models.RiskAndOpportunityRegister RiskAndOpportunityRegister {
            get;
            set;
        }

        public List<Domain.Models.AuditProgram> AuditPrograms {
            get;
            set;
        }

        public Domain.Models.AuditProgram AuditProgram {
            get;
            set;
        }

        public List<Domain.Models.AuditPlan> AuditPlans {
            get;
            set;
        }

        public Domain.Models.AuditPlan AuditPlan {
            get;
            set;
        }

        public List<Domain.Models.Audit> Audits {
            get;
            set;
        }

        public Domain.Models.Audit Audit {
            get;
            set;
        }

        public List<Domain.Models.AuditPlanSupportingDocument> AuditPlanSupportingDocuments {
            get;
            set;
        }

        public Domain.Models.AuditPlanSupportingDocument AuditPlanSupportingDocument {
            get;
            set;
        }

        public List<Domain.Models.AuditSchedule> AuditSchedules {
            get;
            set;
        }

        public Domain.Models.AuditSchedule AuditSchedule {
            get;
            set;
        }

        public List<Domain.Models.AuditApproval> AuditApprovals {
            get;
            set;
        }

        public Domain.Models.AuditApproval AuditApproval {
            get;
            set;
        }

        public List<Domain.Models.AuditFinding> AuditFindings {
            get;
            set;
        }

        public Domain.Models.AuditFinding AuditFinding {
            get;
            set;
        }

        public List<Domain.Models.AuditAuditor> AuditAuditors {
            get;
            set;
        }

        public Domain.Models.AuditAuditor AuditAuditor {
            get;
            set;
        }


    }
}