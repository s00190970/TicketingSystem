using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface ITicketOptionRepository<T> : IDisposable
    {
        List<T> GetAll();
        T Add(T priority);
        void Save();
    }
}
