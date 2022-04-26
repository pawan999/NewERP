using System;

namespace ERPAPI.Entities
{
    public class User
    {
        public string Email { get; set; }
       
           
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public int RoleType { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Location { get; set; }

        public bool IsGKPUser { get; set; }

        public  bool IsAccountManager { get; set; }

        public bool IsDeeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public long AccountManager { get; set; }

        public string token { get; set; }

    }
}
