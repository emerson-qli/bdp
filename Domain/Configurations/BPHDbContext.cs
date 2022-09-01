using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations {
    public class BPHDbContext : DbContext {

        public BPHDbContext() : base("DefaultConnection") {
        }

        public DbSet<Role> Roles {
            set;
            get;
        }

        public DbSet<RoleTemplate> RoleTemplates {
            set;
            get;
        }

        public DbSet<Token> Tokens {
            set;
            get;
        }

        public DbSet<User> Users {
            set;
            get;
        }

        public DbSet<ControlNumber> ControlNumbers {
            get;
            set;
        }


        public DbSet<Setting> Settings {
            get;
            set;
        }

        public DbSet<Country> Countries {
            get;
            set;
        }

        public DbSet<CountryStateRegion> CountryStateRegions {
            get;
            set;
        }

        public DbSet<City> Cities {
            get;
            set;
        }

        public DbSet<Customer> Customers {
            get;
            set;
        }

        public DbSet<Sale> Sales {
            get;
            set;
        }

        public DbSet<Department> Departments {
            get;
            set;
        }


        public DbSet<Employee> Employees {
            get;
            set;
        }

        public DbSet<EmployeeEducation> EmployeeEducations {
            get;
            set;
        }


        public DbSet<EmployeePosition> EmployeePositions {
            get;
            set;
        }


        public DbSet<Organization> Organizations {
            get;
            set;
        }

        public DbSet<OrganizationPolicy> OrganizationPolicies {
            get;
            set;
        }


        public DbSet<OrganizationBusinessProcess> OrganizationBusinessProcesss {
            get;
            set;
        }


        public DbSet<OrganizationChart> OrganizationCharts {
            get;
            set;
        }


        public DbSet<OrganizationCompliance> OrganizationCompliances {
            get;
            set;
        }


        public DbSet<OrganizationContext> OrganizationContexts {
            get;
            set;
        }


        public DbSet<OrganizationContextExternalIssue> OrganizationContextExternalIssues {
            get;
            set;
        }


        public DbSet<OrganizationContextInternalIssue> OrganizationContextInternalIssues {
            get;
            set;
        }


        public DbSet<OrganizationContextPESTLE> OrganizationContextPESTLEs {
            get;
            set;
        }


        public DbSet<OrganizationContextStakeHolder> OrganizationContextStakeHolders {
            get;
            set;
        }


        public DbSet<OrganizationContextSWOT> OrganizationContextSWOTs {
            get;
            set;
        }


        public DbSet<OrganizationDashboard> OrganizationDashboards {
            get;
            set;
        }


        public DbSet<OrganizationProcess> OrganizationProcesss {
            get;
            set;
        }


        public DbSet<OrganizationProfile> OrganizationProfiles {
            get;
            set;
        }


        public DbSet<OrganizationReport> OrganizationReports {
            get;
            set;
        }


        public DbSet<OrganizationVision> OrganizationVisions {
            get;
            set;
        }


        public DbSet<Position> Positions {
            get;
            set;
        }

        public DbSet<Division> Divisions {
            get;
            set;
        }

        public DbSet<Level> Levels {
            get;
            set;
        }

        public DbSet<EmployeeCompetency> EmployeeCompetencies {
            get;
            set;
        }

        public DbSet<EmployeeContactDetail> EmployeeContactDetails {
            get;
            set;
        }

        public DbSet<EmployeeDocument> EmployeeDocuments {
            get;
            set;
        }

        public DbSet<EmployeeExperience> EmployeeExperiences {
            get;
            set;
        }

        public DbSet<EmployeeJobDescription> EmployeeJobDescriptions {
            get;
            set;
        }

        public DbSet<EmployeeKPI> EmployeeKPIs {
            get;
            set;
        }

        public DbSet<EmployeeProgram> EmployeePrograms {
            get;
            set;
        }

        public DbSet<EmployeeQualification> EmployeeQualifications {
            get;
            set;
        }

        public DbSet<EmployeeReport> EmployeeReports {
            get;
            set;
        }

        public DbSet<EmployeeReportRecipient> EmployeeReportRecipients {
            get;
            set;
        }

        public DbSet<EmployeeRoleAndResponsibility> EmployeeRoleAndResponsibilities {
            get;
            set;
        }

        public DbSet<DocumentGroup> DocumentGroups {
            get;
            set;
        }

        public DbSet<CompetencyType> CompetencyTypes {
            get;
            set;
        }


        public DbSet<ActionPlan> ActionPlans {
            get;
            set;
        }


        public DbSet<AnnualPlan> AnnualPlans {
            get;
            set;
        }


        public DbSet<AuditCalendar> AuditCalendars {
            get;
            set;
        }


        public DbSet<AuditTeam> AuditTeams {
            get;
            set;
        }


        public DbSet<AuditUniverse> AuditUniverses {
            get;
            set;
        }


        public DbSet<Audit> Audits {
            get;
            set;
        }

        public DbSet<AuditPlan> AuditPlans {
            get;
            set;
        }

        public DbSet<AuditPlanSupportingDocument> AuditPlanSupportingDocuments {
            get;
            set;
        }

        public DbSet<AuditProgram> AuditPrograms {
            get;
            set;
        }

        public DbSet<AuditSchedule> AuditSchedules {
            get;
            set;
        }

        public DbSet<AuditOrganizationManagementSystem> AuditOrganizationManagementSystems {
            get;
            set;
        }

        public DbSet<AuditOrganizationBusinessProcess> AuditOrganizationBusinessProcesses {
            get;
            set;
        }

        public DbSet<AuditPlanAuditor> AuditProgramAuditors {
            get;
            set;
        }

        public DbSet<ISMSRiskRegister> ISMSRiskRegisters {
            get;
            set;
        }


        public DbSet<IssueTracker> IssueTrackers {
            get;
            set;
        }

        public DbSet<ProcessRiskRegister> ProcessRiskRegisters {
            get;
            set;
        }

        public DbSet<RiskAndOpportunityRegister> RiskAndOpportunityRegisters {
            get;
            set;
        }


        public DbSet<EmployeeAuditor> EmployeeAuditors {
            get;
            set;
        }


        public DbSet<EmployeeAuditee> EmployeeAuditees {
            get;
            set;
        }


        public DbSet<OrganizationProduct> OrganizationProducts {
            get;
            set;
        }


        public DbSet<OrganizationService> OrganizationServices {
            get;
            set;
        }


        public DbSet<OrganizationSubsidiary> OrganizationSubsidiaries {
            get;
            set;
        }

        public DbSet<OrganizationComplianceCertificate> OrganizationComplianceCertificates {
            get;
            set;
        }


        public DbSet<OrganizationManagementSystem> OrganizationManagementSystems {
            get;
            set;
        }


        public DbSet<Rating> Ratings {
            get;
            set;
        }


        public DbSet<OrganizationBusinessProcessStep> OrganizationBusinessProcessSteps {
            get;
            set;
        }


        public DbSet<OrganizationBusinessProcessInteractingDepartment> OrganizationBusinessProcessInteractingDepartments {
            get;
            set;
        }


        public DbSet<OrganizationBusinessProcessSubProcess> OrganizationBusinessProcessSubProcesss {
            get;
            set;
        }


        public DbSet<IssueCategory> IssueCategories {
            get;
            set;
        }

        public DbSet<AuditCategory> AuditCategories {
            get;
            set;
        }


        public DbSet<DocumentCategory> DocumentCategories {
            get;
            set;
        }


        public DbSet<DocumentRequest> DocumentRequests {
            get;
            set;
        }

        public DbSet<DocumentRequestComment> DocumentRequestComments {
            get;
            set;
        }

        public DbSet<DocumentRequestCommentAttachment> DocumentRequestCommentAttachments {
            get;
            set;
        }


        public DbSet<Reviewer> Reviewers {
            get;
            set;
        }


        public DbSet<ReviewerMember> ReviewerMembers {
            get;
            set;
        }


        public DbSet<ApprovingAuthority> ApprovingAuthorities {
            get;
            set;
        }


        public DbSet<ApprovingAuthorityMember> ApprovingAuthorityMembers {
            get;
            set;
        }


        public DbSet<DocumentQualification> DocumentQualifications {
            get;
            set;
        }


        public DbSet<DocumentSection> DocumentSections {
            get;
            set;
        }


        public DbSet<DocumentRequestSupportingDocument> DocumentRequestSupportingDocuments {
            get;
            set;
        }

        public DbSet<DocumentRequestApproval> DocumentRequestApprovals {
            get;
            set;
        }


        public DbSet<Notification> Notifications {
            get;
            set;
        }

        public DbSet<PublishedDocuments> PublishedDocuments {
            get;
            set;
        }

        public DbSet<PublishedDocumentsApproval> PublishedDocumentsApprovals {
            get;
            set;
        }

        public DbSet<PublishedDocumentsComment> PublishedDocumentsComments {
            get;
            set;
        }

        public DbSet<PublishedDocumentsCommentAttachment> PublishedDocumentsCommentAttachments {
            get;
            set;
        }
        public DbSet<PublishedDocumentsSupportingDocument> PublishedDocumentsSupportingDocuments {
            get;
            set;
        }

        public DbSet<DocumentsForChangeRequests> DocumentsForChangeRequestss {
            get;
            set;
        }

        public DbSet<DocumentsForChangeRequestsApproval> DocumentsForChangeRequestsApprovals {
            get;
            set;
        }

        public DbSet<DocumentsForChangeRequestsComment> DocumentsForChangeRequestsComments {
            get;
            set;
        }

        public DbSet<DocumentsForChangeRequestsCommentAttachment> DocumentsForChangeRequestsCommentAttachments {
            get;
            set;
        }
        public DbSet<DocumentsForChangeRequestsSupportingDocument> DocumentsForChangeRequestsSupportingDocuments {
            get;
            set;
        }

        public DbSet<DocumentSetting> DocumentSetting {
            get;
            set;
        }

        public DbSet<AuditApproval> AuditApprovals {
            get;
            set;
        }

        public DbSet<ActivityLog> ActivityLogs {
            get;
            set;
        }

        public DbSet<DocumentRequestForm> DocumentRequestForms {
            get;
            set;
        }

        public DbSet<AuditFinding> AuditFindings {
            get;
            set;
        }

        public DbSet<AuditAuditor> AuditAuditors {
            get;
            set;
        }

        public DbSet<KnowledgeHubStandard> KnowledgeHubStandards {
            get;
            set;
        }

        public DbSet<OrganizationComplianceAccessibleDepartment> OrganizationComplianceAccessibleDepartments {
            get;
            set;
        }

        public DbSet<DocumentRequestExternalDocument> DocumentRequestExternalDocuments {
            get;
            set;
        }

        public DbSet<DocumentClassification> DocumentClassifications {
            get;
            set;
        }

        public DbSet<BusinessRiskType> BusinessRiskTypes {
            get;
            set;
        }

        public DbSet<IssueType> IssueTypes {
            get;
            set;
        }

        public DbSet<SettingEmployeeNotificationRecipient> SettingEmployeeNotificationRecipients {
            get;
            set;
        }

        public DbSet<ExternalDocument> ExternalDocuments {
            get;
            set;
        }
    }
}
