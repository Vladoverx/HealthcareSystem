using CCL.Security.Identity;
using CCL.Security;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using BLL.Services.Impl;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BLL.Tests
{
    public class AppointmentServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                           () => new AppointmentService(nullUnitOfWork)
                                      );
        }

        [Fact]
        public void MakeAppointment_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "Vlad");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IAppointmentService appointmentService = new AppointmentService(mockUnitOfWork.Object);
            // Act
            // Assert
            Assert.Throws<MethodAccessException>(
                               () => appointmentService.MakeAppointment()
                                              );
        }

        [Fact]
        public void MakeAppointment_AppointmentFromDAL_CorrectMappingToAppointmentDTO()
        {
            // Arrange
            User patient = new CCL.Security.Identity.Patient(1, "Mick Jagger");
            SecurityContext.SetUser(patient);
            var appointmentService = GetAppointmentService();
            // Act
            var actualAppointmentDTO = appointmentService.MakeAppointment();
            // Assert
            Console.WriteLine(actualAppointmentDTO.AppointmentId);
            Assert.True(
                actualAppointmentDTO.Patient.FullName == "Mick Jagger");
        }

        IAppointmentService GetAppointmentService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedAppointment = new Appointment()
            {
                Patient = new CCL.Security.Identity.Patient(1, "Mick Jagger"),
            };
            var mockDbSet = new Mock<IAppointmentRepository>();
            mockDbSet.Setup(mock => mock.Get(expectedAppointment.AppointmentId))
                 .Returns(expectedAppointment);

            mockContext
            .Setup(context =>
            context.Appointments)
            .Returns(mockDbSet.Object);
            IAppointmentService appointmentService = new AppointmentService(mockContext.Object);
            return appointmentService;
        }
    }
}
