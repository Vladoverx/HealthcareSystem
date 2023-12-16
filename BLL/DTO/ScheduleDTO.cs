using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Entities.Schedule;

namespace BLL.DTO
{
    public class ScheduleDTO
    {
        public int ScheduleId { get; set; }
        public ScheduleDay CurrentScheduleDay { get; set; }
        public DateTime ScheduleTimeFrom { get; set; }
        public DateTime ScheduleTimeTo { get; set; }
        public int Room { get; set; }
    }
}
