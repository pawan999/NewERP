namespace ERPAPI
{
    public interface IJwtAuth
    {
        string Authentication(string username, string password);
    }
}
