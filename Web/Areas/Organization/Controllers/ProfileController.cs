using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Organization.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.Organization.Controllers {
    public class ProfileController : BaseController {

        public ActionResult Index(Guid? id) {
            var user         = CurrentUser();
            var employee     = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var organization = new OrganizationService().GetAllBy(a => a.Tag == Domain.Models.OrganizationState.Active).FirstOrDefault();

            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }


            if (organization == null) {

                var organizationBlank = new Domain.Models.Organization();

                return View(new OrganizationViewModel {
                    DeletePermission                            = permissionString,
                    Organization                                = organizationBlank,
                    OrganizationVision                          = new Domain.Models.OrganizationVision(),
                    OrganizationPolicies                        = new List<Domain.Models.OrganizationPolicy>(),
                    OrganizationManagementSystems               = new List<Domain.Models.OrganizationManagementSystem>(),
                    OrganizationSubsidiaries                    = new List<Domain.Models.OrganizationSubsidiary>(),
                    OrganizationProducts                        = new List<Domain.Models.OrganizationProduct>(),
                    OrganizationServices                        = new List<Domain.Models.OrganizationService>(),
                    OrganizationValues                          = new List<Domain.Models.OrganizationValue>(),
                    OrganizationCompliances                     = new List<Domain.Models.OrganizationCompliance>(),
                    OrganizationComplianceCertificates          = new List<Domain.Models.OrganizationComplianceCertificate>(),
                    OrganizationBusinessProcesses               = new List<Domain.Models.OrganizationBusinessProcess>(),
                    OrganizationCharts                          = new List<Domain.Models.OrganizationChart>(),
                    User                                        = CurrentUser(),
                    Employee                                    = employee
                });
            }
            else {

                var vision = new OrganizationVisionService().GetAllBy(a => a.OrganizationId == organization.Id).FirstOrDefault();

                return View(new OrganizationViewModel {
                     DeletePermission                           = permissionString,
                     Organization                               = organization,
                     OrganizationVision                         = (vision == null) ? new Domain.Models.OrganizationVision() : vision,
                     OrganizationManagementSystems              = new OrganizationManagementSystemService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationPolicies                       = new OrganizationPolicyService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationSubsidiaries                   = new OrganizationSubsidiaryService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationProducts                       = new OrganizationProductService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationServices                       = new OrganizationServiceService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationCompliances                    = new OrganizationComplianceService().GetAll(organization.Id).ToList(),
                     OrganizationComplianceCertificates         = new OrganizationComplianceCertificateService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationBusinessProcesses              = new OrganizationBusinessProcessService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                     OrganizationValues                         = (vision == null) ? new List<Domain.Models.OrganizationValue>() : new OrganizationValueService().GetAllBy(a => a.OrganizationVisionId == vision.Id).ToList(),
                     OrganizationCharts                         = new OrganizationChartService().GetAll().ToList(),
                     User                                       = CurrentUser(),
                     Employee                                   = employee
                });
            }
        }

        public ActionResult View(Guid id) {
            var user         = CurrentUser();
            var employee     = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var organization = new OrganizationService().Get(id);

            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }

            if (organization == null) {

                var organizationBlank = new Domain.Models.Organization();

                return View(new OrganizationViewModel {
                    DeletePermission                    = permissionString,
                    Organization                        = organizationBlank,
                    OrganizationVision                  = new Domain.Models.OrganizationVision(),
                    OrganizationManagementSystems       = new List<Domain.Models.OrganizationManagementSystem>(),
                    OrganizationSubsidiaries            = new List<Domain.Models.OrganizationSubsidiary>(),
                    OrganizationProducts                = new List<Domain.Models.OrganizationProduct>(),
                    OrganizationServices                = new List<Domain.Models.OrganizationService>(),
                    OrganizationValues                  = new List<Domain.Models.OrganizationValue>(),
                    OrganizationCompliances             = new List<Domain.Models.OrganizationCompliance>(),
                    OrganizationComplianceCertificates  = new List<Domain.Models.OrganizationComplianceCertificate>(),
                    OrganizationBusinessProcesses       = new List<Domain.Models.OrganizationBusinessProcess>(),
                    OrganizationCharts                  = new List<Domain.Models.OrganizationChart>(),
                    User                                = CurrentUser(),
                    Employee                            = employee
                });
            } else {

                var vision = new OrganizationVisionService().GetAllBy(a => a.OrganizationId == organization.Id).FirstOrDefault();

                return View(new OrganizationViewModel {
                    DeletePermission                    = permissionString,
                    Organization                        = organization,
                    OrganizationVision                  = (vision == null) ? new Domain.Models.OrganizationVision() : vision,
                    OrganizationManagementSystems       = new OrganizationManagementSystemService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    OrganizationSubsidiaries            = new OrganizationSubsidiaryService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    OrganizationProducts                = new OrganizationProductService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    OrganizationServices                = new OrganizationServiceService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    OrganizationCompliances             = new OrganizationComplianceService().GetAllBy(a => a.OrganizationId == organization.Id || a.Id == id).ToList(),
                    OrganizationComplianceCertificates  = new OrganizationComplianceCertificateService().GetAllBy(a => a.OrganizationId == organization.Id || a.Id == id).ToList(),
                    OrganizationBusinessProcesses       = new OrganizationBusinessProcessService().GetAllBy(a => a.OrganizationId == organization.Id).ToList(),
                    OrganizationValues                  = (vision == null) ? new List<Domain.Models.OrganizationValue>() : new OrganizationValueService().GetAllBy(a => a.OrganizationVisionId == vision.Id).ToList(),
                    OrganizationCharts                  = new OrganizationChartService().GetAll().ToList(),
                    User                                = CurrentUser(),
                    Employee                            = employee
                });
            }
        }

        [ValidateInput(false)]
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveProfile(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationService().SaveAndGet(viewModel.Organization);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #region Management System
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveManagementSystem(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationManagementSystemService().SaveAndGet(viewModel.OrganizationManagementSystem);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateManagementSystem(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationManagementSystemService().UpdateAndGet(viewModel.OrganizationManagementSystem);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetManagementSystem(Guid id) {
            try {
                var data = new OrganizationManagementSystemService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteManagementSystem(Guid id) {
            try {
                new OrganizationManagementSystemService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetAllManagementSystem() {
            try {
                var data = new OrganizationManagementSystemService().GetAllManagemenSystem().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region subsidiary
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveSubsidiary(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationSubsidiaryService().SaveAndGet(viewModel.OrganizationSubsidiary);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateSubsidiary(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationSubsidiaryService().UpdateAndGet(viewModel.OrganizationSubsidiary);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetSubsidiary(Guid id) {
            try {
                var data = new OrganizationSubsidiaryService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteSubsidiary(Guid id) {
            try {
                new OrganizationSubsidiaryService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetAllSubsidiaries(Guid id) {
            try {
                var data = new OrganizationSubsidiaryService().GetAllBy(a => a.OrganizationId == id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }



        #endregion

        #region product
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveProduct(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationProductService().SaveAndGet(viewModel.OrganizationProduct);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateProduct(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationProductService().UpdateAndGet(viewModel.OrganizationProduct);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteProduct(Guid id) {
            try {
                new OrganizationProductService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult GetProduct(Guid id) {
            try {
                var data = new OrganizationProductService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Service
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveService(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationServiceService().SaveAndGet(viewModel.OrganizationService);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateService(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationServiceService().UpdateAndGet(viewModel.OrganizationService);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult GetService(Guid id) {
            try {
                var data = new OrganizationServiceService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteService(Guid id) {
            try {
                new OrganizationServiceService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Vision

        [ValidateInput(false)]
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveVision(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationVisionService().SaveAndGet(viewModel.OrganizationVision);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }




        #endregion

        #region Values
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveValues(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationValueService().SaveAndGet(viewModel.OrganizationValue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateValue(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationValueService().UpdateAndGet(viewModel.OrganizationValue);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetValue(Guid id) {
            try {
                var data = new OrganizationValueService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteValue(Guid id) {
            try {
                new OrganizationValueService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Policy and Objectives
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SavePolicy(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationPolicyService().SaveAndGet(viewModel.OrganizationPolicy);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdatePolicy(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationPolicyService().UpdateAndGet(viewModel.OrganizationPolicy);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetPolicy(Guid id) {
            try {
                var data = new OrganizationPolicyService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeletePolicy(Guid id) {
            try {
                new OrganizationPolicyService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetAllPolicy() {
            try {
                var data = new OrganizationPolicyService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        #endregion

        #region OrganizationCompliance
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveOrganizationCompliance(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationComplianceService().SaveAndGet(viewModel.OrganizationCompliance);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateOrganizationCompliance(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationComplianceService().UpdateOrganizationCompliance(viewModel.OrganizationCompliance);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetOrganizationCompliance(Guid id) {
            try {
                var data = new OrganizationComplianceService().GetAllIncluding(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetAllOrganizationCompliance() {
            try {
                var data = new OrganizationComplianceService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteOrganizationCompliance(Guid id) {
            try {
                new OrganizationComplianceService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        #endregion

        #region Certificates
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveOrganizationComplianceCertificate(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationComplianceCertificateService().SaveAndGet(viewModel.OrganizationComplianceCertificate);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateOrganizationComplianceCertificate(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationComplianceCertificateService().UpdateAndGet(viewModel.OrganizationComplianceCertificate);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetOrganizationComplianceCertificate(Guid id) {
            try {
                var data = new OrganizationComplianceCertificateService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationView)]
        public JsonResult GetAllOrganizationComplianceCertificate() {
            try {
                var data = new OrganizationComplianceCertificateService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteOrganizationComplianceCertificate(Guid id) {
            try {
                new OrganizationComplianceCertificateService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        #endregion

        #region BusinessProcessManagement
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveOrganizationProcess(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessService().SaveAndGet(viewModel.OrganizationBusinessProcess);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteOrganizationProcess(Guid id) {
            try {
                new OrganizationBusinessProcessService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateOrganizationProcess(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessService().UpdateAndGet(viewModel.OrganizationBusinessProcess);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateOrganizationProcessDepartment(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessService().UpdateOrganizationProcessDepartment(viewModel.OrganizationBusinessProcess);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetAllBusinessProcess() {
            try {
                var data = new OrganizationBusinessProcessService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetAllSubProcess(Guid id) {
            try {
                var data = new OrganizationBusinessProcessSubProcessService().GetAllBy(a => a.OrganizationBusinessProcessId == id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveSubProcess(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessSubProcessService().SaveAndGet(viewModel.OrganizationBusinessProcessSubProcess);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteSubProcess(Guid id) {
            try {
                new OrganizationBusinessProcessSubProcessService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetOrganizationProcess(Guid id) {
            try {
                var data = new OrganizationBusinessProcessService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveStep(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessStepService().SaveAndGet(viewModel.OrganizationBusinessProcessStep);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult UpdateStep(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessStepService().UpdateAndGet(viewModel.OrganizationBusinessProcessStep);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult GetStep(Guid id) {
            try {
                var data = new OrganizationBusinessProcessStepService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteStep(Guid id) {
            try {
                new OrganizationBusinessProcessStepService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveInteractingDepartment(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationBusinessProcessInteractingDepartmentService().SaveAndGet(viewModel.OrganizationBusinessProcessInteractingDepartment);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult DeleteInteractingDepartment(Guid id) {
            try {
                new OrganizationBusinessProcessInteractingDepartmentService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        #endregion

        #region Organization Chart

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationSave)]
        public JsonResult SaveOrganizationalChart(OrganizationViewModel viewModel) {
            try {
                var data = new OrganizationChartService().SaveAndGet(viewModel.OrganizationChart);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.OrganizationDelete)]
        public JsonResult DeleteOrganizationChart(Guid id) {
            try {
                new OrganizationChartService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion
    }
}