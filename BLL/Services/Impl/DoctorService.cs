using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Doctor = DAL.Entities.Doctor;

namespace BLL.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _database;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<DoctorDTO> GetDoctors()
        {
            var doctorsEntitites =
                  _database
                    .Doctors
                    .GetAll();
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Doctor, DoctorDTO>()
                    ).CreateMapper();
            var doctorsDTO =
                mapper
                    .Map<IEnumerable<Doctor>, List<DoctorDTO>>(
                    doctorsEntitites);
            return doctorsDTO;
        }
    }
}
