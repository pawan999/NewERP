using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPEntities
{
    public class ServiceRequest
    {
        public int TransactionId { get; set; }
        public int MemberId { get; set; }

        public string CreatedBy { get; set; }
        public int OnBehalfOf { get; set; }

        public string OnBehalfOfName { get; set; }
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
        public int ServiceRequestId { get; set; }
        public string ServiceRequestName { get; set; }

        public string ServiceDescriptionName { get; set; }
        public int AssignedTo { get; set; }

        public string AssignedToName { get; set; }
        public bool IsApprovalNeeded { get; set; }
        public int Approver { get; set; }

        public string ApproverName { get; set; }
        public DateTime DateCreated { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
        public DateTime DateModified { get; set; }

        public int LastModifiedBy { get; set; }

        public string LastModifiedByName { get; set; }

        public bool IsDeleted { get; set; }

    }
}
