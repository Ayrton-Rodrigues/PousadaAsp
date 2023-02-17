using AutoMapper;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }

        
        public async Task<UserViewModel> GetByDocument(string cpf)
        {
            var user = await _userRepository.GetByDocument(cpf);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<bool> Add(UserViewModel entity)
        {
            
            var users = await GetAll();
            
            if(users.FirstOrDefault(x => x.Cpf == entity.Cpf || x.Email == entity.Email) != null) return false; 
            
            var hashSalt = CreateHashAndSalt(entity.Password);
            
            var newUser = _mapper.Map<User>(entity);

            newUser.PasswordHash = hashSalt.hash;

            newUser.PasswordSalt = hashSalt.salt;

            await _userRepository.Add(newUser); 

            return true;
        }
        public async Task Update(UserViewModel entity)
        {
            var user = _mapper.Map<User>(entity);

            await _userRepository.Update(user);
        }
        public async Task Delete(UserViewModel entity)
        {
            await _userRepository.Remove(entity.Id);
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        public (byte[] hash, byte[] salt) CreateHashAndSalt(string password)
        {
            var saltSize = 16; // Define o tamanho do salt em bytes
            var hashSize = 32; // Define o tamanho do hash em bytes
            var iterations = 10000; // Define o número de iterações a serem usadas na derivação de chave

            // Gera um salt aleatório
            byte[] salt = new byte[saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Deriva uma chave usando a senha e o salt
            var cript = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = cript.GetBytes(hashSize);

            return (hash, salt);

        }
    }
}
