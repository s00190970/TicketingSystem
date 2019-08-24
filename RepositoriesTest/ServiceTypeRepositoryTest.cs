using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Entities;
using Moq;
using NUnit.Framework;

namespace RepositoriesTest
{
    [TestFixture]
    public class ServiceTypeRepositoryTest
    {
        [Test]
        public void GetAllServiceTypes()
        {
            var serviceType = new ServiceType() {Id = 1, Name = "repair"};
            var serviceTypes = new List<ServiceType>();
            serviceTypes.Add(serviceType);

            var dbSetMock = new Mock<DbSet<ServiceType>>();
            dbSetMock.As<IQueryable<ServiceType>>().Setup(x => x.Provider).Returns(serviceTypes.AsQueryable().Provider);
            dbSetMock.As<IQueryable<ServiceType>>().Setup(x => x.Expression).Returns(serviceTypes.AsQueryable().Expression);
            dbSetMock.As<IQueryable<ServiceType>>().Setup(x => x.ElementType).Returns(serviceTypes.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<ServiceType>>().Setup(x => x.GetEnumerator()).Returns(serviceTypes.AsQueryable().GetEnumerator());

            var context = new Mock<TicketDbContext>();
            context.Setup(x => x.Set<ServiceType>()).Returns(dbSetMock.Object);

            var repository = new ServiceTypeRepository(context.Object);
            var result = repository.GetAll();

            Assert.AreEqual(serviceTypes, result);
        }

        [Test]
        public void AddNewServiceType()
        {
            var serviceType = new ServiceType();
            var context = new Mock<TicketDbContext>();
            var dbSetMock = new Mock<DbSet<ServiceType>>();
            context.Setup(x => x.Set<ServiceType>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<ServiceType>())).Returns(serviceType);

            var repository = new ServiceTypeRepository(context.Object);
            repository.Add(serviceType);

            context.Verify(x => x.Set<ServiceType>());
            dbSetMock.Verify(x => x.Add(It.Is<ServiceType>(y => y == serviceType)));
        }
    }
}
