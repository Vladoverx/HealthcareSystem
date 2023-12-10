using DAL.Entities;
using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        internal AppointmentRepository(HospitalContext context) : base(context)
        {
        }
    }
}
