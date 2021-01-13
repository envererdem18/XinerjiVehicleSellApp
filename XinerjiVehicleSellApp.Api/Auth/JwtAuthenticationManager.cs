using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using XinerjiVehicleSellApp.Model.Entities;

namespace XinerjiVehicleSellApp.Api.Auth
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IDictionary<string, string> users;
        private readonly string _key;
        private IEnumerable<Customer> _customers;
        public JwtAuthenticationManager(string key, IEnumerable<Customer> customers )
        {
            _key = key;
            _customers = customers;
        }
        public string Authenticate(string username, string password)
        {
            _customers.ToList().ForEach((c) => users.Add(c.FullName, c.Password));
            if (!users.Any((u) => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
