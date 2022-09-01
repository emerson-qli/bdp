using Domain.Enums;
using Service.Attributes;
using Service.Employee;
using Service.Role;
using Service.Upload;
using Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Areas.HumanCapital.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.HumanCapital.Controllers {
    public class EmployeesController : BaseController {
        
        #region Employee
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Index() {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }

            return View(new HumanCapitalViewModel {
                DeletePermission = permissionString,
                Employees        = new EmployeeService().GetIncludingPositions(),
                User             = CurrentUser(),
                Employee         = employee  
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult Save(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeService().SaveAndGet(viewModel.Employee);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult Update(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeService().UpdateAndGet(viewModel.Employee);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UploadPhoto(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeService().UploadFile(viewModel.Employee);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult Delete(Guid id) {
            try {
                new EmployeeService().Delete(id);
                var pageName = Request.Url.AbsolutePath.Split('/');
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult Get(Guid id) {
            try {
                var data = new EmployeeService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion

        #region Account

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveUser(HumanCapitalViewModel viewModel) {
            try {
                var roleId      = new RoleService().GetRoleByName("Admin").Id;
                var employee    = new EmployeeService().Get(viewModel.Account.EmployeeId);

                var user = new Domain.Models.User {
                     Username = viewModel.Account.Email,
                     Password = viewModel.Account.Password,
                     Fullname = employee.Fullname,
                     Tag      = Domain.Models.UserStatus.Active,
                     RoleId   = roleId
                };

                new UserService().Save(user);

                employee.UserId = user.Id;
                new EmployeeService().Update(employee);
                return Json("User Created", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateUser(HumanCapitalViewModel viewModel) {
            try {
                var roleId = new RoleService().GetRoleByName("Admin").Id;
                var employee = new EmployeeService().GetAllBy(a => a.UserId == viewModel.Account.EmployeeId).FirstOrDefault();

                var user = new Domain.Models.User {
                    Id       = viewModel.Account.EmployeeId,
                    Username = viewModel.Account.Email,
                    Password = viewModel.Account.Password,
                    Fullname = employee.Fullname,
                    Tag      = Domain.Models.UserStatus.Active,
                    RoleId   = roleId
                };

                new UserService().Update(user);

                employee.UserId = user.Id;
                new EmployeeService().Update(employee);
                return Json("User Created", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetUser(Guid id) {
            try {
                var data = new UserService().GetUser(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }


        #endregion

        #region Contact Details
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult ContactDetails(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission       = permissionString,
                Employee               = new EmployeeService().Get(id), 
                EmployeeContactDetails = new EmployeeContactDetailService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                   = CurrentUser(),
                EmployeeUser           = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetContactDetail(Guid id) {
            try {
                var data = new EmployeeContactDetailService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveContactDetail(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeContactDetailService().SaveAndGet(viewModel.EmployeeContactDetail);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateContactDetail(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeContactDetailService().UpdateAndGet(viewModel.EmployeeContactDetail);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteContactDetail(Guid id) {
            try {
                new EmployeeContactDetailService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        #endregion Contact Details

        #region Documents
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Documents(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission  = permissionString,
                Employee          = new EmployeeService().Get(id),
                EmployeeDocuments = new EmployeeDocumentService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User              = CurrentUser(),
                EmployeeUser      = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetDocument(Guid id) {
            try {
                var data = new EmployeeDocumentService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveDocument(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeDocumentService().SaveAndGet(viewModel.EmployeeDocument);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateDocument(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeDocumentService().UpdateAndGet(viewModel.EmployeeDocument);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteDocument(Guid id) {
            try {
                new EmployeeDocumentService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Designations
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Designations(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission    = permissionString,
                Employee            = new EmployeeService().Get(id),
                EmployeePositions   = new EmployeePositionService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                EmployeeUser        = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetDesignation(Guid id) {
            try {
                var data = new EmployeePositionService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SavePosition(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeePositionService().SaveAndGet(viewModel.EmployeePosition);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdatePosition(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeePositionService().UpdateAndGet(viewModel.EmployeePosition);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeletePosition(Guid id) {
            try {
                new EmployeePositionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Competencies
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Competencies(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission        = permissionString,
                Employee                = new EmployeeService().Get(id),
                EmployeeCompetencies    = new EmployeeCompetencyService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                    = CurrentUser(),
                EmployeeUser            = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetCompetency(Guid id) {
            try {
                var data = new EmployeeCompetencyService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveCompetency(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeCompetencyService().SaveAndGet(viewModel.EmployeeCompetency);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateCompetency(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeCompetencyService().UpdateAndGet(viewModel.EmployeeCompetency);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteCompetency(Guid id) {
            try {
                new EmployeeCompetencyService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Experiences
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Experiences(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission    = permissionString,
                Employee            = new EmployeeService().Get(id),
                EmployeeExperiences = new EmployeeExperienceService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                EmployeeUser        = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetExperience(Guid id) {
            try {
                var data = new EmployeeExperienceService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveExperience(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeExperienceService().SaveAndGet(viewModel.EmployeeExperience);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateExperience(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeExperienceService().UpdateAndGet(viewModel.EmployeeExperience);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteExperience(Guid id) {
            try {
                new EmployeeExperienceService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Education
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Education(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }

            return View(new HumanCapitalViewModel {
                DeletePermission    = permissionString,
                Employee            = new EmployeeService().Get(id),
                EmployeeEducations  = new EmployeeEducationService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                EmployeeUser        = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetEducation(Guid id) {
            try {
                var data = new EmployeeEducationService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveEducation(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeEducationService().SaveAndGet(viewModel.EmployeeEducation);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateEducation(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeEducationService().UpdateAndGet(viewModel.EmployeeEducation);
                return Json(data, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteEducation(Guid id) {
            try {
                new EmployeeEducationService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region JobDescriptions
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult JobDescriptions(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }

            return View(new HumanCapitalViewModel {
                DeletePermission        = permissionString,
                Employee                = new EmployeeService().Get(id),
                EmployeeJobDescriptions = new EmployeeJobDescriptionService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                    = CurrentUser(),
                EmployeeUser            = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetJobDescription(Guid id) {
            try {
                var data = new EmployeeJobDescriptionService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveJobDescription(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeJobDescriptionService().SaveAndGet(viewModel.EmployeeJobDescription);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateJobDescription(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeJobDescriptionService().UpdateAndGet(viewModel.EmployeeJobDescription);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteJobDescription(Guid id) {
            try {
                new EmployeeJobDescriptionService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region KPIs
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult KPIs(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission    = permissionString,
                Employee            = new EmployeeService().Get(id),
                EmployeeKPIs        = new EmployeeKPIService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                = CurrentUser(),
                EmployeeUser        = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetKPI(Guid id) {
            try {
                var data = new EmployeeKPIService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveKPI(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeKPIService().SaveAndGet(viewModel.EmployeeKPI);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateKPI(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeKPIService().UpdateAndGet(viewModel.EmployeeKPI);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteKPI(Guid id) {
            try {
                new EmployeeKPIService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Programs
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Programs(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission = permissionString,
                Employee         = new EmployeeService().Get(id),
                EmployeePrograms = new EmployeeProgramService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User             = CurrentUser(),
                EmployeeUser     = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetProgram(Guid id) {
            try {
                var data = new EmployeeProgramService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveProgram(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeProgramService().SaveAndGet(viewModel.EmployeeProgram);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateProgram(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeProgramService().UpdateAndGet(viewModel.EmployeeProgram);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteProgram(Guid id) {
            try {
                new EmployeeProgramService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Qualifications
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Qualifications(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission        = permissionString,
                Employee                = new EmployeeService().Get(id),
                EmployeeQualifications  = new EmployeeQualificationService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                    = CurrentUser(),
                EmployeeUser            = employee
            });
        }


        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetQualification(Guid id) {
            try {
                var data = new EmployeeQualificationService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveQualification(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeQualificationService().SaveAndGet(viewModel.EmployeeQualification);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateQualification(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeQualificationService().UpdateAndGet(viewModel.EmployeeQualification);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteQualification(Guid id) {
            try {
                new EmployeeQualificationService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region RoleAndResponsibilities
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult RoleAndResponsibilities(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission                = permissionString,
                Employee                        = new EmployeeService().Get(id),
                EmployeeRoleAndResponsibilities = new EmployeeRoleAndResponsibilityService().GetAllBy(a => a.EmployeeId == id).OrderByDescending(a => a.CreatedAt).ToList(),
                User                            = CurrentUser(),
                EmployeeUser                    = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetRoleAndResponsibility(Guid id) {
            try {
                var data = new EmployeeRoleAndResponsibilityService().Get(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveRoleAndResponsibility(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeRoleAndResponsibilityService().SaveAndGet(viewModel.EmployeeRoleAndResponsibility);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateRoleAndResponsibility(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeRoleAndResponsibilityService().UpdateAndGet(viewModel.EmployeeRoleAndResponsibility);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteRoleAndResponsibility(Guid id) {
            try {
                new EmployeeRoleAndResponsibilityService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region Reports
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public ActionResult Reports(Guid id) {
            var user             = CurrentUser();
            var employee         = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var permissionHelper = new Service.Helper.PermissionHelper();
            var permissionDelete = permissionHelper.GetPermission(Domain.Enums.ApplicationElement.OrganizationDelete);
            var permissionString = "Denied";
            if (permissionDelete != false) {
                permissionString = "Granted";
            }
            return View(new HumanCapitalViewModel {
                DeletePermission = permissionString,
                Employee         = new EmployeeService().Get(id),
                EmployeeReports  = new EmployeeReportService().GetAllIncludingRecipients(id),
                User             = CurrentUser(),
                EmployeeUser     = employee
            });
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeView)]
        public JsonResult GetReport(Guid id) {
            try {
                var data = new EmployeeReportService().GetIncluding(id);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult SaveReport(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeReportService().SaveAndGet(viewModel.EmployeeReport);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult UpdateReport(HumanCapitalViewModel viewModel) {
            try {
                var data = new EmployeeReportService().UpdateAndGet(viewModel.EmployeeReport);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeDelete)]
        public JsonResult DeleteReport(Guid id) {
            try {
                new EmployeeReportService().Delete(id);
                return Json("Deleted", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }
        #endregion

        #region JSON
        [AuthorizeRoleBase(ApplicationElement = ApplicationElement.EmployeeSave)]
        public JsonResult GetAll() {
            try {
                var data = new EmployeeService().GetAll().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> UploadDocument(HttpPostedFileBase file) {
            try {
                return await Task.Run(() => {
                    var result = new UploadService().UploadDocument(file);
                    return Json(result, JsonRequestBehavior.AllowGet);
                });
            }
            catch (Exception exception) {
                return JsonError("Error " + exception.Message);
            }
        }

        #endregion

    }
}