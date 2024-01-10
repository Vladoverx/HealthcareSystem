using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentRepository Appointments { get; }
        IPatientRepository Patients { get; }
        IDoctorRepository Doctors { get; }
        IScheduleRepository Schedules { get; }
        void Save();
    }
}
