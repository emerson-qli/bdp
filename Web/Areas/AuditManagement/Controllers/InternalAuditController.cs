using Domain.Enums;
using Service.Attributes;
using Service.Audit;
using Service.Employee;
using Service.InternalAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.AuditManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.AuditManagement.Controllers {
    public class InternalAuditController : BaseController {

        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new AuditManagementViewModel {
                AuditPrograms   = new AuditProgramService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                AuditPlans      = new AuditPlanService().GetAllIncluding().ToList(),
                User            = CurrentUser(),
                Employee        = employee
            });
        }

        public ActionResult View(Guid id) {
            var user                        = CurrentUser();
            var employee                    = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();

            var auditProcesses              = new List<Domain.Models.AuditOrganizationBusinessProcess>();

            var auditPlan                   = new AuditPlanService().Get(id);

            var auditPlanSupportDocuments   = new List<Domain.Models.AuditPlanSupportingDocument>();
            var auditPlanAuditors           = new List<Domain.Models.AuditPlanAuditor>();
            var auditApprovals              = new List<Domain.Models.AuditApproval>();
            var auditSchedule               = new List<Domain.Models.AuditSchedule>();

            return View(new AuditManagementViewModel {
                AuditPrograms                       = new AuditProgramService().GetAll().OrderByDescending(a => a.CreatedAt).ToList(),
                Audits                              = new AuditService().GetAllBy(a => a.Id == auditPlan.AuditId).ToList(),
                AuditOrganizationBusinessProcesses  = new AuditOrganizationBusinessProcessService().GetAllBy(a => a.AuditId == auditPlan.AuditId).ToList(),
                AuditPlanSupportingDocuments        = new AuditPlanSupportingDocumentService().GetAllBy(a => a.AuditPlanId == auditPlan.Id).ToList(),
                AuditPlanAuditors                   = new AuditPlanAuditorService().GetAllBy(a => a.AuditPlanId == auditPlan.Id).ToList(),
                AuditApprovals                      = new AuditApprovalService().GetAllBy(a => a.AuditPlanId == auditPlan.Id).ToList(),
                AuditSchedules                      = new AuditScheduleService().GetAllBy(a => a.AuditPlanId == auditPlan.Id).ToList(),
                User                                = CurrentUser(),
                AuditPlan                           = auditPlan,
                Employee                            = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult Save(AuditManagementViewModel viewModel) {
            try {
                var data = new InternalAuditService().SaveAndGet(viewModel.InternalAudit);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult Update(AuditManagementViewModel viewModel) {
            try {
                var data = new InternalAuditService().UpdateAndGet(viewModel.InternalAudit);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new InternalAuditService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SubmitAuditPlan(Guid id) {
            try {
                new AuditPlanService().Submit(id);
                return Json("submitted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditProgram(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditProgramService().SaveAndGet(viewModel.AuditProgram);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditMSType(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditService().SaveMStype(viewModel.Audit);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditPlanFile(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditPlanService().SaveSupportingFile(viewModel.AuditPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditPlanSchedule(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditPlanService().SaveSchedule(viewModel.AuditPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditPlanAuditors(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditPlanService().SaveAuditors(viewModel.AuditPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditFinding(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditFindingService().SaveAndGet(viewModel.AuditFinding);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult UpdateAuditFinding(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditFindingService().UpdateAndGet(viewModel.AuditFinding);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditProcess(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditService().SaveProcess(viewModel.Audit);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult UpdateAuditSchedule(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditService().UpdateSchedule(viewModel.Audit);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult SaveAuditPlan(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditService().NewAuditPlan(viewModel.Audit);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult UpdateAuditPlan(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditPlanService().UpdateAuditPlan(viewModel.AuditPlan);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult ApproveAudit(Guid id, Guid employeeId) {
            try {
                new AuditApprovalService().ApproveAudit(id, employeeId);
                return Json("Submitted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult UpdateAuditProgram(AuditManagementViewModel viewModel) {
            try {
                var data = new AuditProgramService().UpdateAndGet(viewModel.AuditProgram);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteProgram(Guid id) {
            try {
                new AuditProgramService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteManagementSystem(Guid id) {
            try {
                new AuditOrganizationManagementSystemService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditProcess(Guid id) {
            try {
                new AuditOrganizationBusinessProcessService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditor(Guid id) {
            try {
                new AuditPlanAuditorService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditPlan(Guid id) {
            try {
                new AuditPlanService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditPlanAuditor(Guid id) {
            try {
                new AuditPlanAuditorService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditPlanSupportingFile(Guid id) {
            try {
                new AuditPlanSupportingDocumentService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditPlanSchedule(Guid id) {
            try {
                new AuditScheduleService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditDelete)]
        public JsonResult DeleteAuditFinding(Guid id) {
            try {
                new AuditFindingService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }



        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditSave)]
        public JsonResult GetAll() {
            try {
                var data = new InternalAuditService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult Get(Guid id) {
            try {
                var data = new InternalAuditService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAuditPrograms() {
            try {
                var data = new AuditProgramService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAuditProgram(Guid id) {
            try {
                var data = new AuditProgramService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAudit(Guid id) {
            try {
                var data = new AuditService().GetAudit(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAllAudited(Guid id) {
            try {
                var data = new AuditService().GetAllAudited(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAudited(Guid id) {
            try {
                var data = new AuditPlanService().GetAll(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAllAuditFinding(Guid id) {
            try {
                var data = new AuditFindingService().GetFinding(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAuditFinding(Guid id) {
            try {
                var data = new AuditFindingService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAuditPlan(Guid id) {
            try {
                var data = new AuditPlanService().GetAll(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }



        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.InternalAuditView)]
        public JsonResult GetAuditMSType(Guid id) {
            try {
                var data = new AuditService().GetAllIncluding(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


    }
}