using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using DevIO.Api.Extensions;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using Projeto.Asp.Api.PousadaAsp.Domain.Enums;
using Microsoft.Extensions.Options;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Services
{
    public class LoginService
    {


        private readonly JwtSettings _jwtSettings;

        public LoginService(IOptions<JwtSettings> jwtSettings)
        {

            _jwtSettings = jwtSettings.Value;
        }


        public string Login(UserViewModel user) 
        {


            if (user != null)
            {
                var token = GenerateToken(user);
                
                return token;
            }

            return null;
        }

        private string GenerateToken(UserViewModel user)
        {
     
            
            var claims = new List<Claim>();
            

            claims.Add(new Claim(ClaimTypes.Name, user.Nome));
            claims.Add(new Claim("Info", user.Cpf));
            claims.Add(new Claim("Info", user.Email));
            claims.Add(new Claim("role", user.RolesId.ToString()));

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var credential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Emissor,
                audience: _jwtSettings.ValidoEm,                
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credential
            );

                

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }


    }
}