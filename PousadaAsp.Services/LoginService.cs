using PousadaAsp.Domain.Interfaces;
using PousadaAsp.Domain.Interfaces.IService;
using PousadaAsp.Domain.ViewModels;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.Enums;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using PousadaAsp.Domain.Utils;
using PousadaAsp.Domain.Services;

namespace PousadaAsp.Domain.Services
{
    public class LoginService : BaseService
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IUserRepository _userRepo;

        public LoginService(IOptions<JwtSettings> jwtSettings, IUserRepository userRepo, INotifier notifier) : base(notifier)
        {
            _jwtSettings = jwtSettings.Value;
            _userRepo = userRepo; 
        }

        public async Task<string> Login(LoginViewModel login) 
        {           

            var users = await _userRepo.GetAll();

            var user = users.FirstOrDefault(x => x.Email == login.Email);            

            if (user == null)
            {
                NotifyError("Usuário não encontrado!");
                return null;                
            }

            var result = ConfirmHashAndSalt(login.Password, user.PasswordHash, user.PasswordSalt);

            if (result)
            {
                var token = GenerateToken(user);
                return token;                     
            }

            return null;
        }

        private string GenerateToken(User user)
        {
            
            var claims = new List<Claim>();
            claims.Add(new Claim("Nome", user.Nome));
            claims.Add(new Claim("Document", user.Cpf));
            claims.Add(new Claim("Email", user.Email));
            claims.Add(new Claim(ClaimTypes.Role.Split('/').Last(), user.Roles.ToString()));

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

        private bool ConfirmHashAndSalt(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hashSize = 32;
            var iterations = 10000;

            var encrypt = new Rfc2898DeriveBytes(password, passwordSalt, iterations);
            byte[] computedHash = encrypt.GetBytes(hashSize);
            

            for (int i = 0; i < hashSize; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }


    }
}