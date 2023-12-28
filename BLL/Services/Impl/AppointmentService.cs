using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient = CCL.Security.Identity.Patient;

namespace BLL.Services.Impl
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _database;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public AppointmentDTO MakeAppointment()
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Patient))
            {
                throw new MethodAccessException();
            }

            Patient patient = new Patient(1, "Mick Jagger");
            var appointment = new Appointment();
            appointment.Patient = patient;
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Appointment, AppointmentDTO>()
                    ).CreateMapper();
            var appointmentDTO = mapper.Map<AppointmentDTO>(appointment);

            return appointmentDTO;
        }
    }
}
