using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Entities.Appointment;

namespace BLL.DTO
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentState CurrentAppointmentState { get; set; }
    }
}
