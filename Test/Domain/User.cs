using Test.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public Role RoleDetail { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
