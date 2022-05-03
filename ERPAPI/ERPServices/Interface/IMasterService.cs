using ERPAPI.Entities;
using ERPEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServices.Interface
{
    public interface IMasterService
    {

        List<Department> GetAllDepartments();
        List<Status> GetAllSttaus();
        List<Role> GetAllRoles();

        List<ServiceRequestType> GetServiceRequestTypes();
    }
}
