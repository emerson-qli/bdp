using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.Account.Models {
    public class AccountViewModel : BaseViewModel {
        public Domain.Models.Employee Employee {
            get;
            set;
        }

        public Domain.Models.Employee CurrentEmployee {
            get;
            set;
        }

        public Domain.Models.User User {
            get;
            set;
        }

        public List<Domain.Models.EmployeeReport> EmployeeReports {
            get;
            set;
        }

        public string CheckId {
            get;
            set;
        }
    }
}