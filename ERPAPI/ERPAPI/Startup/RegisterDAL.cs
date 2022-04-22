

using ERPDAL.Implementation;
using ERPDAL.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ERPAPI
{
    public static class RegisterDAL
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IMembersDAL, MembersDAL>();

            services.AddTransient<IServiceRequestDAL, ServiceRequestDAL>();
        }
        
    }
}
