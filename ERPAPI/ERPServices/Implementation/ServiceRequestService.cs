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
        public ServiceRequestService(IServiceRequestDAL serviceRequestDAL)
        {
            this.obServiceRequestDAL = serviceRequestDAL;
        }
     
        public bool AddServiceRequest(ServiceRequest serviceRequest)
        {
         return obServiceRequestDAL.AddServiceRequest(serviceRequest);
        }

        public bool UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            return obServiceRequestDAL.UpdateServiceRequest(serviceRequest);
        }

       


        public List<ServiceRequest> GetAllServiceRequest()
        {
            return obServiceRequestDAL.GetAllServiceRequest();
        }
    }
}
