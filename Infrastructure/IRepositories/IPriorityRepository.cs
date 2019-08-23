using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IPriorityRepository : IDisposable
    {
        List<Priority> GetPriorities();
        Priority Add(Priority priority);
        void Save();
    }
}
