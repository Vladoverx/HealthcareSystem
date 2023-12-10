using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Appointment
    {
        public enum State
        {
            Scheduled,
            CarriedOut,
            Canceled,
            Finished
        }

        public int AppointmentId { get; set; }
        public required Doctor Doctor { get; set; }
        public required Patient Patient { get; set; }
        public required DateTime AppointmentDate { get; set; }
        public required State AppointmentState { get; set; }
    }
}
