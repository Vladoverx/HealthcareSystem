using BLL.Services.Impl;
using CCL.Security.Identity;
using CCL.Security;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Doctor = DAL.Entities.Doctor;

namespace BLL.Tests;

public class DoctorServiceTests
{
    [Fact]
    public void Ctor_InputNull_ThrowArgumentNullException()
    {
        // Arrange
        IUnitOfWork nullUnitOfWork = null;
        // Act
        // Assert
        Assert.Throws<ArgumentNullException>(
        () => new DoctorService(nullUnitOfWork)
        );
    }

    [Fact]
    public void GetDoctors_DoctorFromDAL_CorrectMappingToDoctorDTO()
    {
        // Arrange
        var doctorService = GetDoctorService();
        // Act
        var actualDoctorDto = doctorService.GetDoctors().First();
        // Assert
        Assert.True(
        actualDoctorDto.DoctorId == 1
        && actualDoctorDto.FullName == "Jack Black"
        && actualDoctorDto.Specialization == "Dentist"
        && actualDoctorDto.Experience == 13
        );
    }

    IDoctorService GetDoctorService()
    {
        var mockContext = new Mock<IUnitOfWork>();
        var expectedDoctor = new Doctor()
        {
            DoctorId = 1,
            FullName = "Jack Black",
            Specialization = "Dentist",
            Experience = 13,
        };
        
        var mockDbSet = new Mock<IDoctorRepository>();
        mockDbSet
        .Setup(z =>
         z.GetAll()).Returns(new List<Doctor>() { expectedDoctor });

        mockContext
        .Setup(context =>
        context.Doctors)
        .Returns(mockDbSet.Object);
        IDoctorService doctorService = new DoctorService(mockContext.Object);
        return doctorService;
    }
}