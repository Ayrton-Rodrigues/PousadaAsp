using AutoMapper;
using PousadaAsp.Domain.Entity;
using PousadaAsp.Domain.Interfaces;
using PousadaAsp.Domain.Interfaces.IService;
using PousadaAsp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using PousadaAsp.Domain.Validations;
using FluentValidation;

namespace PousadaAsp.Domain.Services
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

        public async Task<bool> Add(UserViewModel entity)
        {
            
            var users = await GetAll();
            
            if(users.FirstOrDefault(x => x.Cpf == entity.Cpf || x.Email == entity.Email) != null) return false;

            var validator = Validator(new UserValidator(), entity);

            if (!validator)  return false;

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
            var saltSize = 16; // tamanho do salt em bytes
            var hashSize = 32; // tamanho do hash em bytes
            var iterations = 10000; // Informa quantas iterações serão usadas para modificar a chave
         
            byte[] salt = new byte[saltSize]; // Salt aleatório
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Cria uma chave usando a senha e o salt
            var cript = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = cript.GetBytes(hashSize);

            return (hash, salt);

        }
        
        public bool Validator(UserValidator user, UserViewModel userVm)
        {
            var validator = user.Validate(userVm);
            if (validator.IsValid) return true;

            foreach(var error in validator.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return false;
        }
    }
}
