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
        public Day ScheduleDay { get; set; }
        public DateTime ScheduleTimeFrom { get; set; }
        public DateTime ScheduleTimeTo { get; set; }
        public int Room { get; set; }
    }
}
