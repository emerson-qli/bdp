using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Areas.Shared.ViewModels;

namespace Web.Areas.HumanCapital.Data {
    public class HumanCapitalViewModel : BaseViewModel {

        public List<Domain.Models.Employee> Employees {
            get;
            set;
        }

        public Domain.Models.Employee Employee {
            get;
            set;
        }

        public Domain.Models.Employee EmployeeUser {
            get;
            set;
        }

        public Domain.Models.EmployeeEducation EmployeeEducation {
            get;
            set;
        }

        public List<Domain.Models.EmployeeEducation> EmployeeEducations {
            get;
            set;
        }

        public List<Domain.Models.Department> Departments {
            get;
            set;
        }

        public Domain.Models.Department Department {
            get;
            set;
        }

        public List<Domain.Models.Position> Positions {
            get;
            set;
        }

        public Domain.Models.Position Position {
            get;
            set;
        }

        public List<Domain.Models.Level> Levels {
            get;
            set;
        }

        public Domain.Models.Level Level {
            get;
            set;
        }

        public List<Domain.Models.Division> Divisions {
            get;
            set;
        }

        public Domain.Models.Division Division {
            get;
            set;
        }


        public List<Domain.Models.EmployeeContactDetail> EmployeeContactDetails {
            get;
            set;
        }

        public Domain.Models.EmployeeContactDetail EmployeeContactDetail {
            get;
            set;
        }


        public List<Domain.Models.EmployeeDocument> EmployeeDocuments {
            get;
            set;
        }

        public Domain.Models.EmployeeDocument EmployeeDocument {
            get;
            set;
        }



        public List<Domain.Models.EmployeeExperience> EmployeeExperiences {
            get;
            set;
        }

        public Domain.Models.EmployeeExperience EmployeeExperience {
            get;
            set;
        }


        public List<Domain.Models.EmployeeJobDescription> EmployeeJobDescriptions {
            get;
            set;
        }

        public Domain.Models.EmployeeJobDescription EmployeeJobDescription {
            get;
            set;
        }


        public List<Domain.Models.EmployeePosition> EmployeePositions {
            get;
            set;
        }

        public Domain.Models.EmployeePosition EmployeePosition {
            get;
            set;
        }


        public List<Domain.Models.EmployeeKPI> EmployeeKPIs {
            get;
            set;
        }

        public Domain.Models.EmployeeKPI EmployeeKPI {
            get;
            set;
        }


        public List<Domain.Models.EmployeeProgram> EmployeePrograms {
            get;
            set;
        }

        public Domain.Models.EmployeeProgram EmployeeProgram {
            get;
            set;
        }


        public List<Domain.Models.EmployeeQualification> EmployeeQualifications {
            get;
            set;
        }

        public Domain.Models.EmployeeQualification EmployeeQualification {
            get;
            set;
        }


        public List<Domain.Models.EmployeeReport> EmployeeReports {
            get;
            set;
        }

        public Domain.Models.EmployeeReport EmployeeReport {
            get;
            set;
        }


        public List<Domain.Models.EmployeeRoleAndResponsibility> EmployeeRoleAndResponsibilities {
            get;
            set;
        }

        public Domain.Models.EmployeeRoleAndResponsibility EmployeeRoleAndResponsibility {
            get;
            set;
        }


        public List<Domain.Models.EmployeeCompetency> EmployeeCompetencies {
            get;
            set;
        }

        public Domain.Models.EmployeeCompetency EmployeeCompetency {
            get;
            set;
        }


        public int EmployeeCounts {
            get;
            set;
        }

        public int DepartmentCounts {
            get;
            set;
        }

        public int PositionCounts {
            get;
            set;
        }

        public string DeletePermission {
            get;
            set;
        }


        public Account Account {
            get;
            set;
        }

    }

    public class Account {
        public string Email {
            get;
            set;
        }

        public string Password {
            get;
            set;
        }

        public Guid EmployeeId {
            get;
            set;
        }

    }

}