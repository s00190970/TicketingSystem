using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entities;

namespace Infrastructure.IRepositories
{
    public interface IServiceTypeRepository : ITicketOptionRepository<ServiceType>
    {
    }
}
