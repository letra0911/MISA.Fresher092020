using MISA.CukCuk.Models;
using MISA.CukCuk.Properties;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;

namespace MISA.CukCuk.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeId = Guid.NewGuid();
        }
        public Guid EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender;

        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Nữ";
                    case 1:
                        return "Nam";
                    case 2:
                        return "Khác";
                    default:
                        return "Không xác định";
                }
            }
        }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? PossitionId { get; set; }
        public string PossitionName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string TaxCode { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? WorkStatus { get; set; }
        public string WorkStatusName
        {
            get
            {
                if (WorkStatus == null)
                    return string.Empty;

                var resource = Resources.ResourceManager.GetObject("ResourcesVN");
                switch ((WorkStatus)WorkStatus)
                {
                    case Models.WorkStatus.Stopped:
                        return ResourcesVN.Enum_WorkStatus_Stopped;
                    case Models.WorkStatus.Working:
                        return ResourcesVN.Enum_WorkStatus_Working;
                    case Models.WorkStatus.Waiting:
                        return ResourcesVN.Enum_WorkStatus_Waitiing;
                    default:
                        return string.Empty;
                }
            }
        }

    }
}
