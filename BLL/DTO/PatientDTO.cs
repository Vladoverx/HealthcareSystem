﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
