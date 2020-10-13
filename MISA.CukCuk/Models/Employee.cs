using MISA.CukCuk.Models;
using System;
using System.Collections.Generic;

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
        public int Gender;

        public string GenderName
        {
            get {
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
        public string Cmt { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssueBy { get; set; }
        public sbyte? Position { get; set; }
        public sbyte? Department { get; set; }
        public string TaxCode { get; set; }
        public DateTime? JoinDate { get; set; }
        public sbyte? Status { get; set; }
        public double Wage { get; set; }
    }
}
