using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class OrganizationChart : BaseModel<OrganizationChartState> {

        public Guid EmployeeId {
            get;
            set;
        }

        public string EmployeeFullName {
            get;
            set;
        }

        public Guid PositionId {
            get;
            set;
        }

        public string PostionName {
            get;
            set;
        }

        public string OriginalFileName {
            get;
            set;
        }

        public string UniqueFileName {
            get;
            set;
        }

    }

    public enum OrganizationChartState {
        Active,
        Inactive
    }
}
