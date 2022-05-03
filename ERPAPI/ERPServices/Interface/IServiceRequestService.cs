using ERPAPI.Entities;
using ERPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServices.Interface
{
    public interface IServiceRequestService
    {

      
        bool AddServiceRequest(ServiceRequest serviceRequest);

        bool UpdateServiceRequest(ServiceRequest serviceRequest);

       

        List<ServiceRequest> GetAllServiceRequest(User objuser);

        List<ServiceRequest> GetServiceRequestById(int transactionId);
    }
}
