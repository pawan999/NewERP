using ERPAPI.Entities;

namespace ERPAPI
{
    public interface IJwtAuth
    {
        User Authentication(string username, string password);
    }
}
