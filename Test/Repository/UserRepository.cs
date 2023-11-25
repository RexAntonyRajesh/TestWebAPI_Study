using Test.Domain;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Test.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
    }
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) :
             base(configuration)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            var userList = new List<User>();
            var role = new Role();
            role.Id = 1;
            role.RoleName = "Admin";
            userList.Add(new Domain.User
            {
                Id = 1,
                Name = "Mukesh kumar",
                Email = "Mukesh@123.com",
                Phone = "9884567891",
                UserName = "Mukesh01",
                Role = "Admin",
                RoleDetail = role
            });

            return userList;
        }

        public async Task<User> GetUserById(int id)
        {
            var role = new Role();
            role.Id = 1;
            role.RoleName = "Admin";
            return new Domain.User
            {
                Id = 1,
                Name = "Mukesh kumar",
                Email = "Mukesh@123.com",
                Phone = "9884567891",
                UserName = "Mukesh01",
                Role = "Admin",
                RoleDetail = role
            };
        }
    }
}
