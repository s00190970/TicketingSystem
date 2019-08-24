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
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        public ServiceTypeRepository(TicketDbContext contextObject)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<ServiceType> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceType Add(ServiceType priority)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
