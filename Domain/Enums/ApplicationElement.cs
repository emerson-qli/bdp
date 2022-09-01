using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums {
    public enum ApplicationElement {
        ElementUnknown                       = 0,
        CustomerView                         = 100,
        CustomerSave                         = 101,
        CustomerDelete                       = 102,

        LocationView                         = 200,
        LocationSave                         = 201,
        LocationDelete                       = 202,

        SaleView                             = 300,
        SaleSave                             = 301,
        SaleDelete                           = 303,

        DepartmentView                       = 400,
        DepartmentSave                       = 401,
        DepartmentDelete                     = 402,

        EmployeeView                         = 500,
        EmployeeSave                         = 501,
        EmployeeDelete                       = 502,
        
        PositionView                         = 600,
        PositionSave                         = 601,
        PositionDelete                       = 602,
        
        LevelView                            = 700,
        LevelSave                            = 701,
        LevelDelete                          = 702,
        
        DivisionView                         = 800,
        DivisionSave                         = 801,
        DivisionDelete                       = 802,

        HumanCapitalDashboard                = 900,
        MainDashboard                        = 901,
        AuditManagementDashboard             = 902,
        InformationManagementDashboard       = 903,
        OrganizationDashboard                = 904,
        RiskManagementDashboard              = 905,

        ActionPlanView                       = 1000,
        ActionPlanSave                       = 1001,
        ActionPlanDelete                     = 1002,

        AnnualPlanView                       = 1100,
        AnnualPlanSave                       = 1101,
        AnnualPlanDelete                     = 1102,
        
        AuditCalendarView                    = 1200,
        AuditCalendarSave                    = 1201,
        AuditCalendarDelete                  = 1202,
        
        AuditTeamView                        = 1300,
        AuditTeamSave                        = 1301,
        AuditTeamDelete                      = 1302,
        
        AuditUniverseView                    = 1400,
        AuditUniverseSave                    = 1401,
        AuditUniverseDelete                  = 1402,
        
        /*ExternalAuditView                    = 1500,
        ExternalAuditSave                    = 1501,
        ExternalAuditDelete                  = 1502,*/
        
        InternalAuditView                    = 1600,
        InternalAuditSave                    = 1601,
        InternalAuditDelete                  = 1602,
        
        IssueTrackerView                     = 1700,
        IssueTrackerSave                     = 1701,
        IssueTrackerDelete                   = 1702,
        
        ISMSRiskRegisterView                 = 1800,
        ISMSRiskRegisterSave                 = 1801,
        ISMSRiskRegisterDelete               = 1802,
        
        AuditManagementView                  = 1900,
        AuditManagementSave                  = 1901,
        AuditManagementDelete                = 1902,
        
        RiskAndOpportunityRegisterView       = 2000,
        RiskAndOpportunityRegisterSave       = 2001,
        RiskAndOpportunityRegisterDelete     = 2002,

        SettingDocumentTypeView              = 2100,
        SettingDocumentTypeSave              = 2101,
        SettingDocumentTypeDelete            = 2102,

        CompetencyTypeView                   = 2200,
        CompetencyTypeSave                   = 2201,
        CompetencyTypeDelete                 = 2202,

        RatingView                           = 2300,
        RatingSave                           = 2301,
        RatingDelete                         = 2302,

        OrganizationView                     = 2400,
        OrganizationSave                     = 2401,
        OrganizationDelete                   = 2402,

        OrganizationProfileView              = 2403,
        OrganizationProfileSave              = 2404,
        OrganizationProfileDelete            = 2405,

        OrganizationContextView              = 2406,
        OrganizationContextSave              = 2407,
        OrganizastionContextDelete           = 2408,

        OrganizationReportView               = 2409,
        OrganizationReportSave               = 2410,
        OrganizationReportDelete             = 2411,

        IssueCategoryView                    = 2500,
        IssueCategorySave                    = 2501,
        IssueCategoryDelete                  = 2502,

        SWOTView                             = 2600,
        SWOTSave                             = 2601,
        SWOTDelete                           = 2602,

        DocumentCategoryView                 = 2700,
        DocumentCategorySave                 = 2701,
        DocumentCategoryDelete               = 2702,

        ApprovingAuthorityView               = 2800,
        ApprovingAuthoritySave               = 2801,
        ApprovingAuthorityDelete             = 2802,

        ReviewerView                         = 2900,
        ReviewerSave                         = 2901,
        ReviewerDelete                       = 2902,

        DocumentSectionView                  = 3000,
        DocumentSectionSave                  = 3001,
        DocumentSectionDelete                = 3002,

        DocumentQualificationView            = 3100,
        DocumentQualificationSave            = 3101,
        DocumentQualificationDelete          = 3102,

        DocumentRequestView                  = 3200,
        DocumentRequestSave                  = 3201,
        DocumentRequestDelete                = 3202,

        AuditCategoryView                    = 3300,
        AuditCategorySave                    = 3301,
        AuditCategoryDelete                  = 3302,

        PublishedDocumentsView               = 3400,
        PublishedDocumentsSave               = 3401,
        PublishedDocumentsDelete             = 3402,

        DocumentsForChangeRequestsView       = 3500,
        DocumentsForChangeRequestsSave                  = 3501,
        DocumentsForChangeRequestsDelete                = 3502,

        DocumentLogView                                 = 3600,
        DocumentLogSave                                 = 3601,
        DocumentLogDelete                               = 3602,

        InformationManagementView                       = 3603,
        InformationManagementSave                       = 3604,
        InformationManagementDelete                     = 3605,

        InformationManagementDocumentsViews             = 3606,
        InformationManagementDocumentsSave              = 3607,
        InformationManagementDocumentsDelete            = 3608,

        InformationManagementDocumentRequestsView       = 3609,
        InformationManagementDocumentRequestsSave       = 3610,
        InformationManagementDocumentRequestsDelete     = 3611,

        InformationManagementDocumentChangeView         = 3612,
        InformationManagementDocumentChangeSave         = 3613,
        InformationManagementDocumentChangeDelete       = 3614,

        InformationManagementDocumentSettingsView       = 3615,
        InformationManagementDocumentSettingsSave       = 3616,
        InformationManagementDocumentSettingsDelete     = 3617,

        InformationManagementDocumentReportView         = 3618,
        InformationManagementDocumentReportSave         = 3619,
        InformationManagementDocumentReportDelete       = 3620,

        InformationManagementDocumentObsoletionView     = 3621,
        InformationManagementDocumentObsoletionSave     = 3622,
        InformationManagementDocumentObsoletionDelete   = 3623,

        HumanCapitalView                                = 3700,
        HumanCapitalSave                                = 3701,
        HumanCapitalDelete                              = 3701,

        HumanCapitalDivisionView                        = 3801,
        
        HumanCapitalDepartmentView                      = 3901,

        HumanCapitalPositionView                        = 4000,

        HumanCapitalEmployeeView                        = 4100,

        AuditManagementAuditUniverse                    = 4200,
        AuditManagementAuditTerms                       = 4300,
        AuditManagementInternalAudit                    = 4400,
        AuditManagementAnnualPlan                       = 4500,
        AuditManagementAuditCalendar                    = 4600,
        AuditManagementIssueTracker                     = 4700,
        AuditManagementActionPlan                       = 4800,
        AuditManagementExternalAudit                    = 4900,
        AuditManagementReports                          = 5100,

        SystemView                                      = 5000,
        SystemDelete                                    = 5001,
        SystemSave                                      = 5002,

        SystemRole                                      = 5003,
        SystemUser                                      = 5004,

        RiskManagementView                              = 6000,
        RiskManagementSave                              = 6001,
        RiskManagementDelete                            = 6002,

        RiskManagementOpportunityRegister               = 6100,
        RiskManagementISMSRiskRegister                  = 6200,
        RiskManagementProcessRiskRegister               = 6300,
        RiskManangementReports                          = 6400,

        SettingView                                     = 7001,
        SettingDocumentTypes                            = 7002,
        SettingRatings                                  = 7003,
        SettingLevel                                    = 7004,
        SettingIssueCategory                            = 7005,
        SettingAuditCategory                            = 7006,
        SettingDocumentCategories                       = 7007,
        SettingDocumentQualifications                   = 7008,
        SettingDocumentSections                         = 7009,
        SettingApprovingAuthority                       = 7010,
        SettingCompetencyTypes                          = 7011,
        SettingAuditAuditors                            = 7012,
        SettingPrintSettings                            = 7013,
        SettingDocumentClassification                   = 7014,
        SettingBusinessRiskTypes                        = 7015,
        SettingIssueTypes                               = 7016,
        SettingGeneral                                  = 7017,

        AuditPlanView                                   = 8100,
        AuditPlanEdit                                   = 8101,
        AuditPanDelete                                  = 8102,

        Administration                                  = 8200,

        AuditAuditorView                                = 8300,
        AuditAuditorSave                                = 8301,
        AuditAuditorDelete                              = 8302,

        KnowledgeHubView                                = 8400,
        KnowledgeHubStandard                            = 8401,

        KnowledgeHubStandardView                        = 8500,
        KnowledgeHubStandardSave                        = 8501,
        KnowledgeHubStandardDelete                      = 8502,

        DocumentClassificationView                      = 8600,
        DocumentClassificationSave                      = 8601,
        DocumentClassificationDelete                    = 8602,

        BusinessRiskTypeView                            = 8700,
        BusinessRiskTypeSave                            = 8701,
        BusinessRiskTypeDelete                          = 8702,

        IssueTypeView                                   = 8801,
        IssueTypeSave                                   = 8802,
        IssueTypeDelete                                 = 8803,

        GeneralView                                     = 8900,
        GeneralSave                                     = 8901,
        GeneralDelete                                   = 8902,

        ExternalDocumentView                            = 9000,
        ExternalDocumentSave                            = 9001,
        ExternalDocumentDelete                          = 9003

    }
}
