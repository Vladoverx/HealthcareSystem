using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Schedule
    {
        public enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public required Day ScheduleDay { get; set; }
        public required DateTime ScheduleTimeFrom { get; set; }
        public required DateTime ScheduleTimeTo { get; set; }
        public required int Room { get; set; }
    }
}
