using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.Entities;
using System.Security.Cryptography.X509Certificates;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputDoctorInstance_CalledAddMethodOfDBSetWithDoctorInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<HospitalContext>().Options;
            var mockContext = new Mock<HospitalContext>(opt);
            var mockDbSet = new Mock<DbSet<Doctor>>();
            mockContext.Setup(context => context.Set<Doctor>()).Returns(mockDbSet.Object);

            var repository = new TestDoctorRepository(mockContext.Object);
            Doctor expectedDoctor = new Mock<Doctor>().Object;

            //Act
            repository.Create(expectedDoctor);

            // Assert
            mockDbSet.Verify(
                               dbSet => dbSet.Add(
                                      expectedDoctor
                                      ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId() 
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<HospitalContext>().Options;
            var mockContext = new Mock<HospitalContext>(opt);
            var mockDbSet = new Mock<DbSet<Doctor>>();
            mockContext.Setup(context => context.Set<Doctor>()).Returns(mockDbSet.Object);
        
            Doctor expectedDoctor = new Doctor() { DoctorId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedDoctor.DoctorId)).Returns(expectedDoctor);
            var repository = new TestDoctorRepository(mockContext.Object);

            //Act
            var actualDoctor = repository.Get(expectedDoctor.DoctorId);

            // Assert
            mockDbSet.Verify(
                             dbSet => dbSet.Find(
                                   expectedDoctor.DoctorId
                                   ), Times.Once());
            Assert.Equal(expectedDoctor, actualDoctor);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<HospitalContext>().Options;
            var mockContext = new Mock<HospitalContext>(opt);
            var mockDbSet = new Mock<DbSet<Doctor>>();
            mockContext.Setup(context => context.Set<Doctor>()).Returns(mockDbSet.Object);

            var expectedDoctor = new Doctor { DoctorId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedDoctor.DoctorId)).Returns(expectedDoctor);
            Doctor removedDoctor = null;
            mockDbSet.Setup(mock => mock.Remove(It.IsAny<Doctor>())).Callback<Doctor>(d => removedDoctor = d);
            var repository = new TestDoctorRepository(mockContext.Object);

            // Act
            repository.Delete(expectedDoctor.DoctorId);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Find(expectedDoctor.DoctorId), Times.Once());
            mockDbSet.Verify(dbSet => dbSet.Remove(It.IsAny<Doctor>()), Times.Once());
            Assert.Equal(expectedDoctor, removedDoctor);
        }
    }
}
