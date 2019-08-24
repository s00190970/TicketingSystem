using API.Models;
using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.IRepositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RepositoriesTest
{
    [TestFixture]
    public class PriorityRepositoryTest
    {
        [Test]
        public void GetAllPriorities()
        {
            var priority = new Priority() { Id = 1, Name = "test" };
            var priorities = new List<Priority>();
            priorities.Add(priority);

            var dbSetMock = new Mock<DbSet<Priority>>();
            dbSetMock.As<IQueryable<Priority>>().Setup(x => x.Provider).Returns(priorities.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Priority>>().Setup(x => x.Expression).Returns(priorities.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Priority>>().Setup(x => x.ElementType).Returns(priorities.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Priority>>().Setup(x => x.GetEnumerator()).Returns(priorities.AsQueryable().GetEnumerator());

            var context = new Mock<TicketDbContext>();
            context.Setup(x => x.Set<Priority>()).Returns(dbSetMock.Object);

            var repository = new PriorityRepository(context.Object);
            var result = repository.GetAll();

            Assert.AreEqual(priorities, result);
        }

        [Test]
        public void AddNewPriority()
        {
            var priority = new Priority();
            var context = new Mock<TicketDbContext>();
            var dbSetMock = new Mock<DbSet<Priority>>();
            context.Setup(x => x.Set<Priority>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Priority>())).Returns(priority);

            var repository = new PriorityRepository(context.Object);
            repository.Add(priority);

            context.Verify(x => x.Set<Priority>());
            dbSetMock.Verify(x => x.Add(It.Is<Priority>(y => y == priority)));
        }

    }
}
