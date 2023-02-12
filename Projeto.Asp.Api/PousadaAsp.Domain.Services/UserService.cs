using AutoMapper;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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

            var user = await GetByDocument(entity.Cpf);
            if (user != null) return false;
            
            var newUser = _mapper.Map<User>(entity);
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
    }
}
