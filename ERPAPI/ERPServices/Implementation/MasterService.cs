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
    public class MasterService : IMasterService
    {
        private readonly IMasterDAL objMasterDAL;
        public MasterService(IMasterDAL masterDAL)
        {
            this.objMasterDAL = masterDAL;
        }
       

        public List<Department> GetAllDepartments()
        {
            return objMasterDAL.GetAllDepartments();
        }
        public List<Status> GetAllSttaus()
        {
            return objMasterDAL.GetAllSttaus();
        }
        public List<Role> GetAllRoles()
        {
            return objMasterDAL.GetAllRoles();
        }
    }
}
