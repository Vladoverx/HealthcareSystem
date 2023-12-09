using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public required string FullName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
