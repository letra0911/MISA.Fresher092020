using System;
using System.Collections.Generic;

namespace MISA.Common.Models
{
    public partial class Customer
    {
        public Guid CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MemberCardCode { get; set; }
        public double? DebitAmount { get; set; }
        public string Address { get; set; }
        public bool IsStopFollow { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string CustomerGroupName { get; set; }
    }
}
