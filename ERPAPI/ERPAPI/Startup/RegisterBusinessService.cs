using ERPServices.Implementation;
using ERPServices.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ERPAPI
{
    public class RegisterBusinessService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IMembersService, MembersService>();
            services.AddTransient<IServiceRequestService, ServiceRequestService>();
            services.AddTransient<IMasterService, MasterService>();

            services.AddSingleton<IJwtAuth, JwtAuth>();
        }

    }
}
