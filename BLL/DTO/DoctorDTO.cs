using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public Schedule Schedule { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
    }
}
