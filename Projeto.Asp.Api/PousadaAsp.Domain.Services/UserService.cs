using AutoMapper;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces;
using Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<UserViewModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task Add(UserViewModel entity)
        {
            var user = _mapper.Map<User>(entity);
            await _userRepository.Add(user);
       
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
