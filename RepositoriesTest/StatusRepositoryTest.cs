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
    public class StatusRepositoryTest
    {
        [Test]
        public void GetAllStatuses()
        {
            var status = new Status() {Id = 1, Name = "in progress"};
            var statuses = new List<Status>();
            statuses.Add(status);

            var dbSetMock = new Mock<DbSet<Status>>();
            dbSetMock.As<IQueryable<Status>>().Setup(x => x.Provider).Returns(statuses.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Status>>().Setup(x => x.Expression).Returns(statuses.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Status>>().Setup(x => x.ElementType).Returns(statuses.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Status>>().Setup(x => x.GetEnumerator()).Returns(statuses.AsQueryable().GetEnumerator());

            var context = new Mock<TicketDbContext>();
            context.Setup(x => x.Set<Status>()).Returns(dbSetMock.Object);

            var repository = new StatusRepository(context.Object);
            var result = repository.GetAll();

            Assert.AreEqual(statuses, result);
        }

        [Test]
        public void AddNewStatus()
        {
            var status = new Status();
            var context = new Mock<TicketDbContext>();
            var dbSetMock = new Mock<DbSet<Status>>();
            context.Setup(x => x.Set<Status>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Status>())).Returns(status);

            var repository = new StatusRepository(context.Object);
            repository.Add(status);

            context.Verify(x => x.Set<Status>());
            dbSetMock.Verify(x => x.Add(It.Is<Status>(y => y == status)));
        }
    }
}
