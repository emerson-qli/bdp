using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Employee : BaseModel<EmployeeState> {

        public Guid? UserId {
            get;
            set;
        }

        public string Fullname {
            set;
            get;
        }

        public string Firstname {
            get;
            set;
        }

        public string Middlename {
            get;
            set;
        }

        public string Lastname {
            get;
            set;
        }

        public string Address {
            get;
            set;
        }

        public string Nationality {
            get;
            set;
        }

        public DateTime DateOfBirth {
            get;
            set;
        }

        public int Age {
            get;
            set;
        }

        public string Gender {
            get;
            set;
        }

        public DateTime? JoiningDate {
            get;
            set;
        }

        public DateTime? ResigningDate {
            get;
            set;
        }

        public string Languages {
            get;
            set;
        }

        public List<EmployeeAuditor> Auditors {
            get;
            set;
        }

        public List<EmployeeAuditee> Auditees {
            get;
            set;
        }

        public List<EmployeePosition> EmployeePositions {
            get;
            set;
        }

        public List<EmployeeContactDetail> ContactDetails {
            get;
            set;
        }

        public List<EmployeeDocument> Documents {
            get;
            set;
        }

        public List<EmployeeExperience> Experiences {
            get;
            set;
        }

        public List<EmployeeJobDescription> JobDescriptions {
            get;
            set;
        }

        public List<EmployeeCompetency> EmployeeCompetencies {
            get;
            set;
        }

        public List<EmployeeReport> Reports {
            get;
            set;
        }

        public List<EmployeeProgram> Programs {
            get;
            set;
        }

        public List<EmployeeKPI> EmployeeKPIs {
            get;
            set;
        }

        public List<EmployeeQualification> EmployeeQualifications {
            get;
            set;
        }

        public List<EmployeeRoleAndResponsibility> EmployeeRoleAndResponsibilities {
            get;
            set;
        }

        public string Photo {
            get;
            set;
        }

        public string PhotoOriginalFileName {
            get;
            set;
        }


    }

    public enum EmployeeState {
        Active,
        Inactive
    }
}
