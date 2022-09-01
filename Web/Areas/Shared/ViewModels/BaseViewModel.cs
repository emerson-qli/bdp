using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Shared.ViewModels {
    public class BaseViewModel {


        public Domain.Models.User User {
            get;
            set;
        }

        public Domain.Models.Employee Employee {
            get;
            set;
        }


    }
}