using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Schedule
    {
        public enum ScheduleDay
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
        public ScheduleDay CurrentScheduleDay { get; set; }
        public DateTime ScheduleTimeFrom { get; set; }
        public DateTime ScheduleTimeTo { get; set; }
        public int Room { get; set; }
    }
}
