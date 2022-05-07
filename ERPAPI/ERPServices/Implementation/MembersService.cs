using ERPAPI.Entities;
using ERPDAL.Interface;
using ERPServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPServices.Implementation
{
    public class MembersService : IMembersService
    {
        private readonly IMembersDAL objMembersDAL;
        public MembersService(IMembersDAL membersDAL)
        {
            this.objMembersDAL = membersDAL;
        }
        public User AuthenticateMember(string user, string password)
        {
            return objMembersDAL.AuthenticateMember(user, password);
        }

        public bool AddMember(User user)
        {
         return objMembersDAL.AddMember(user);
        }

        public bool UpdateMember(User user)
        {
            return objMembersDAL.UpdateMember(user);
        }

        public bool DeleteMember(long id)
        {
            return objMembersDAL.DeleteMember(id);
        }


        public List<User> GetAllTeammembers()
        {
            return objMembersDAL.GetAllTeammembers();
        }

        public List<User> GetAllTeammembersByRole(int RoleId)
        {
            return objMembersDAL.GetAllTeammembersByRole(RoleId);
        }

        public List<User> GetAllTeammembersByDepartment(int DepartmentId)
        {
            return objMembersDAL.GetAllTeammembersByDepartment(DepartmentId);
        }

        public List<User> GetAllAccountManager()
        {
            return objMembersDAL.GetAllAccountManager();
        }

        public List<User> GetAllTeammembersById(long Id)
        {
            return objMembersDAL.GetAllTeammembersById(Id);
        }
    }
}
