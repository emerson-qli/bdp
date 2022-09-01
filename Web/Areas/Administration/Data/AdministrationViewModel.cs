using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.Administration.Data {
    public class AdministrationViewModel : BaseViewModel {
        public List<Domain.Models.ActivityLog> ActivityLogs {
            get;
            set;
        }

        public Domain.Models.ActivityLog ActivityLog {
            get;
            set;
        }
    }
}