using AutoMapper;
using Test.Repository;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Test.Service;
using System.Linq;
using System;

namespace Test.services
{
    public interface IUserServices
    {
        Task<List<UserResponse>> GetUsers();
        Task<UserResponse> GetUserById(int id);
    }
    public class UserServices: IUserServices
    {
        private IMapper mapper;
        private IUserRepository userRepository;
        private IConfiguration config;

        #region Constructor
        public UserServices(IUserRepository userRepository,
            IConfiguration config,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.config = config;
        }
        #endregion
        public async Task<List<UserResponse>> GetUsers()
        {

                var users = await userRepository.GetUsers();
                return mapper.Map<List<Domain.User>, List<UserResponse>>(users);

        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var users = await userRepository.GetUserById(id);
            return mapper.Map<Domain.User, UserResponse>(users);
        }


    }
}
