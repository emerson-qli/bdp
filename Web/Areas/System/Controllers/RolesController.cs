using Domain.Enums;
using Service.Attributes;
using Service.Role;
using Service.RoleTemplate;
using Web.Areas.Shared.Controllers;
using Web.Areas.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Employee;

namespace Web.Areas.System.Controllers {
    public class RolesController : BaseController {

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        public ActionResult Index() {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SystemRolesIndexViewModel {
                Roles = new RoleService().GetAllRoles(true),
                Employee = employee
            });
        }

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        public ActionResult View(Guid id) {
            var user = CurrentUser();
            var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            return View(new SystemRolesViewViewModel {
                Role = new RoleService().GetRole(id),
                RoleTemplates = new RoleTemplateService().GetRoleTemplate(id),
                Employee = employee
            });
        }

        



        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        //[HttpPost]
        public JsonResult GrantPermission(SystemRolesGrantPermissionViewModel viewModel) {
            try {
                new RoleTemplateService().Save(viewModel.RoleTemplate);
                return Json("Access successfully granted.", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        public JsonResult GrantPermissions(SystemRolesGrantPermissionsViewModel viewModel) {
            try {
                new RoleTemplateService().SavePermissions(viewModel.RoleTemplates);
                return Json("Access successfully granted.", JsonRequestBehavior.AllowGet);
            } catch(Exception exception) {
                return JsonError(exception.Message);
            }
        }

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        //[HttpPost]
        public JsonResult RevokePermission(Guid roleTemplateId) {
            try {
                new RoleTemplateService().Delete(roleTemplateId);
                return Json("Access successfully revoked.", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        public JsonResult RevokePermissions(Guid id) {
            try {
                new RoleTemplateService().RemovePermissions(id);
                return Json("Access successfully revoked.", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        public JsonResult Edit(Guid id) {
            try {
                return Json(new RoleService().GetRole(id), JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(String.Format("Unable to retrieve role's information. The following error occured: {0}", exception.Message));
            }
        }

        

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        //[HttpPost]
        public JsonResult Update(SystemRolesEditViewModel viewModel) {
            try {
                new RoleService().Update(viewModel.Role);
                return Json("Role successfully updated", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(String.Format("Unable to update role. The following error occured: {0}", exception.Message));
            }
        }

        //[AuthorizeRoleBase(ApplicationElement = ApplicationElement.ElementUnknown)]
        //[HttpPost]
        public JsonResult Create(SystemRolesCreateViewModel viewModel) {
            try {
                new RoleService().Save(viewModel.Role);
                return Json("Role successfully created", JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(String.Format("Unable to create role. The following error occured: {0}", exception.Message));
            }
        }

        
    }
}