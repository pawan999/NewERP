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

        public bool DeleteMember(User user)
        {
            return objMembersDAL.DeleteMember(user);
        }


        public List<User> GetAllTeammembers()
        {
            return objMembersDAL.GetAllTeammembers();
        }
    }
}
