using AutoMapper;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Interfaces.IService
{
    public class IUserService : IService<UserViewModel, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public Task<IEnumerable<UserViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<UserViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task Add(UserViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserViewModel entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(UserViewModel entity)
        {
            throw new NotImplementedException();
        }



    }
}
