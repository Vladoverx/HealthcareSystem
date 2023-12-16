﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Doctor : User
    {
        public Doctor(int userId, string fullName, string email, string address, DateOnly dateOfBirth, string userType)
            : base(userId, fullName, email, address, dateOfBirth, nameof(Doctor))
        {
        }
    }
}