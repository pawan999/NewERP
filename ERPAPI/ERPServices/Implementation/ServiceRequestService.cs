using ERPAPI.Entities;
using ERPDAL.Interface;
using ERPEntities;
using ERPServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServices.Implementation
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestDAL obServiceRequestDAL;

        private readonly IMembersService ObjmembersService;
        public ServiceRequestService(IServiceRequestDAL serviceRequestDAL, IMembersService membersService)
        {
            this.obServiceRequestDAL = serviceRequestDAL;
            this.ObjmembersService = membersService;
        }
     
        public bool AddServiceRequest(ServiceRequest serviceRequest)
        {
         return obServiceRequestDAL.AddServiceRequest(serviceRequest);
        }

        public bool UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            return obServiceRequestDAL.UpdateServiceRequest(serviceRequest);
        }




        public List<ServiceRequest> GetAllServiceRequest(User objuser)


        {
            List <User> lstUsers= ObjmembersService.GetAllTeammembers();
            List<ServiceRequest> lstserviceRequests= obServiceRequestDAL.GetAllServiceRequest(objuser);

            foreach(ServiceRequest sr in lstserviceRequests)
            {
                var createdByName = from x in lstUsers
                             where x.Id == sr.MemberId
                             select x.FirstName;

                var onBehalfOfName = from x in lstUsers
                                where x.Id == sr.OnBehalfOf
                                select x.FirstName;

                var approverName = from x in lstUsers
                                where x.Id == sr.Approver
                                select x.FirstName;

                var modifiedByName = from x in lstUsers
                                where x.Id == sr.LastModifiedBy
                                select x.FirstName;

                var assignedToName = from x in lstUsers
                                where x.Id == sr.AssignedTo
                                select x.FirstName;

                sr.CreatedBy = Convert.ToString(createdByName.FirstOrDefault());
                sr.OnBehalfOfName = Convert.ToString(onBehalfOfName.FirstOrDefault());
                sr.ApproverName = Convert.ToString(approverName.FirstOrDefault());
                sr.LastModifiedByName = Convert.ToString(modifiedByName.FirstOrDefault());
                sr.AssignedToName = Convert.ToString(assignedToName.FirstOrDefault());
            }

            return lstserviceRequests;
        }




        public List<ServiceRequest> GetServiceRequestById(int transactionId)


        {
            List<User> lstUsers = ObjmembersService.GetAllTeammembers();
            List<ServiceRequest> lstserviceRequests = obServiceRequestDAL.GetServiceRequestById(transactionId);

            foreach (ServiceRequest sr in lstserviceRequests)
            {
                var createdByName = from x in lstUsers
                                    where x.Id == sr.MemberId
                                    select x.FirstName;

                var onBehalfOfName = from x in lstUsers
                                     where x.Id == sr.OnBehalfOf
                                     select x.FirstName;

                var approverName = from x in lstUsers
                                   where x.Id == sr.Approver
                                   select x.FirstName;

                var modifiedByName = from x in lstUsers
                                     where x.Id == sr.LastModifiedBy
                                     select x.FirstName;

                var assignedToName = from x in lstUsers
                                     where x.Id == sr.AssignedTo
                                     select x.FirstName;

                sr.CreatedBy = Convert.ToString(createdByName.FirstOrDefault());
                sr.OnBehalfOfName = Convert.ToString(onBehalfOfName.FirstOrDefault());
                sr.ApproverName = Convert.ToString(approverName.FirstOrDefault());
                sr.LastModifiedByName = Convert.ToString(modifiedByName.FirstOrDefault());
                sr.AssignedToName = Convert.ToString(assignedToName.FirstOrDefault());
            }

            return lstserviceRequests;
        }
    }
}
