using ERPAPI.Entities;
using ERPServices.Interface;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPAPI
{
    public class JwtAuth: IJwtAuth
    {

        private readonly string username = "kirtesh";
        private readonly string password = "Demo1";
        private readonly string key  = "This is my first Test Key";
        private readonly IMembersService objMembersService;
        
        public JwtAuth( IMembersService membersService)
        {
           
            this.objMembersService = membersService;
        }
        public string Authentication(string username, string password)
        {
            User objUser = objMembersService.AuthenticateMember(username, password);

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject( objUser))
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
