using ERPAPI.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace ERPAPI
{
    public static class ClaimsManager
    {

        public static User GetCurrentUser(HttpContext context)
        {
            User album = new();

            foreach (var claim in context.User.Claims)
            {
                if (claim.Type == ClaimTypes.UserData)
                {
                   var objuser = JsonConvert.DeserializeObject(claim.Value);

                    JObject jalbum = objuser as JObject;

                    // Copy to a static Album instance
                     album = jalbum.ToObject<User>();
                }
            }

            return album;

        }
    }
}
