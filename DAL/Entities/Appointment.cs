using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security.Identity;

namespace DAL.Entities
{
    public class Appointment
    {
        public enum AppointmentState
        {
            Scheduled,
            CarriedOut,
            Canceled,
            Finished
        }

        public int AppointmentId { get; set; }
        public User Doctor { get; set; }
        public User Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentState CurrentAppointmentState { get; set; }
    }
}
