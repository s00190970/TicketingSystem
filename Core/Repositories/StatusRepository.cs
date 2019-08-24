using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.IRepositories;

namespace Core.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        public StatusRepository(TicketDbContext contextObject)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Status> GetAll()
        {
            throw new NotImplementedException();
        }

        public Status Add(Status priority)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
