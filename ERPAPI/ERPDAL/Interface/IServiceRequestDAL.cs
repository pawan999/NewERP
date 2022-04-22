using ERPAPI.Entities;
using ERPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPDAL.Interface
{
    public interface IServiceRequestDAL
    {
       

        bool AddServiceRequest(ServiceRequest serviceRequest);

        bool UpdateServiceRequest(ServiceRequest serviceRequest);

       

        List<ServiceRequest> GetAllServiceRequest();

    }
}
