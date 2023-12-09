using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public int ScheduleId { get; set; }
        public required string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Specialization { get; set; }
        public required string Experience { get; set; }
    }
}
