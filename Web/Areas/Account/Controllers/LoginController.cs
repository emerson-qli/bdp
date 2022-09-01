using Domain.Models;
using Service.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Notification;
using Service.Persistence;
using Web.Areas.Shared.ViewModels;
using Service.Attributes;
using Domain.Enums;
using Web.Areas.Shared.Controllers;
using Service.User;
using Facebook;
using System.Web.Security;
using Service.Employee;

namespace Web.Areas.Account.Controllers {
    public class LoginController : BaseController {

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public JsonResult Index(AccountLoginViewModel viewModel) {

            var user = new Domain.Models.User();

            try {
                user = new AuthenticationService().Authenticate(viewModel.Email, viewModel.Password);
                UserSessionService<User>.Initialise(user);
            } catch (Exception exception) {
                if (viewModel.Password == null) {
                    return JsonError("Username/Password is incorrect");
                }
                return JsonError(exception.Message);
            }

            return Json(new LoginViewModel {
                Direction = "/Dashboard/Default/",
                Status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Authenticate(Account account) {
            try {
                var user = new UserService().GetAuthenticatedUser(account.Username, account.Password);
                if (user != null) {
                    return Json(new ValidResponse {
                         Status = true,
                         User = user,
                    }, JsonRequestBehavior.AllowGet);
                } else {
                    return Json(new ValidResponse {
                        Status = false,
                        User = CurrentUser()
                    }, JsonRequestBehavior.AllowGet);
                }
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

        public JsonResult CheckSession() {

            try {
                return Json((CurrentUser() != null), JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }

        }

        public JsonResult GetCurrentUser() {
            try {
                var data = CurrentUser();
                if(data != null) {
                    data.Password = "weh?";
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }

        }

        public JsonResult GetNotifications() {
            try {
                var user = CurrentUser();
                var notifications = new List<Domain.Models.Notification>();
                if(user != null) {
                    var employee = new EmployeeService().GetAllBy(a => a.UserId == user.Id).FirstOrDefault();
                    if(employee != null) {
                        notifications = new NotificationService().GetAllBy(a => a.UserId == employee.Id).OrderByDescending(a => a.CreatedAt).ToList();
                    }
                }

                dynamic data = new {
                    Notifications = notifications,
                    Count         = notifications.Where(a => a.Tag == NotificationState.New).Count()
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }

        }

        public JsonResult ReadNotifcation(Guid id) {
            try {

                new NotificationService().Read(id);
                return Json("Read", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception) {
                return JsonError(exception.Message);
            }

        }

        public JsonResult GetEmployeePhoto() {
            try {
                var photo = "";
                var data = CurrentUser();
                if (data != null) {
                    var employee = new EmployeeService().GetPhoto(data.Id);
                    if(employee != null) {
                        photo = employee.Photo;
                    }
                }
                return Json(photo, JsonRequestBehavior.AllowGet);
            } catch (Exception exception) {
                return JsonError(exception.Message);
            }
        }

    }




    public class Account {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ValidResponse {

        public Domain.Models.User User {
            get;
            set;
        }

        public bool Status {
            get;
            set;
        }

    }

    public class LoginViewModel {

        public bool Status {
            get;
            set;
        }

        public string Direction {
            get;
            set;
        }

    }
}