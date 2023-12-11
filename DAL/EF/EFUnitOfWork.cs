using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.EF
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private HospitalContext db;
        private AppointmentRepository appointmentRepository;
        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        private ScheduleRepository scheduleRepository;
        private bool disposed = false;
        public EFUnitOfWork(DbContextOptions options)
        {
            db = new HospitalContext(options);
        }
        IAppointmentRepository IUnitOfWork.Appointments
        {
            get
            {
                if (appointmentRepository == null)
                    appointmentRepository = new AppointmentRepository(db);
                return appointmentRepository;
            }
        }
        IPatientRepository IUnitOfWork.Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(db);
                return patientRepository;
            }
        }
        IDoctorRepository IUnitOfWork.Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(db);
                return doctorRepository;
            }
        }
        IScheduleRepository IUnitOfWork.Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
