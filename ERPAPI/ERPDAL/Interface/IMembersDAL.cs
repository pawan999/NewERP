using ERPAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPDAL.Interface
{
    public interface IMembersDAL
    {
        User AuthenticateMember(string user, string password);

        bool AddMember(User user);

        bool UpdateMember(User user);

        bool DeleteMember(User user);


        List<User> GetAllTeammembers();

    }
}
