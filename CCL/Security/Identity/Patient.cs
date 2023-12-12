using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Patient : User
    {
        public Patient(int userId, string fullName, string email, string address, DateOnly dateOfBirth, string userType) 
            : base(userId, fullName, email, address, dateOfBirth, nameof(Patient))
        {
        }
    }
}
