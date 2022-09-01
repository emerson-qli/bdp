using Service.ActivityLog;
using Service.Document;
using Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.InformationManagement.Data;
using Web.Areas.Shared.Controllers;

namespace Web.Areas.InformationManagement.Controllers {
    public class ReportsController : BaseController {
        // GET: InformationManagement/Reports
        public ActionResult Index() {
            var user                = CurrentUser();
            var employee            = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
            var documents           = new DocumentRequestService().GetAll().ToList();
            var externalDocuments   = new ExternalDocumentService().GetAll().ToList();
            return View(new InformationManagementViewModel {
                User                = user,
                Employee            = employee,
                DocumentRequests    = documents,
                ExternalDocuments   = externalDocuments
            });
        }
    }
}