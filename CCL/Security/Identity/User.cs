using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string fullName, string userType)
        {
            UserId = userId;
            FullName = fullName;
            UserType = userType;
        }
        public int UserId { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Address { get; }
        public DateOnly DateOfBirth { get; }
        protected string UserType { get; }
    }
}
