using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Unity;
using System.Text;
using System.Threading.Tasks;

namespace Core.IRepositories
{
    public class PriorityRepository : IPriorityRepository
    {
        [Dependency]
        public TicketDbContext context { get; set; }

        public Priority Add(Priority priority)
        {
            return context.Priorities.Add(priority);
        }

        public List<Priority> GetPriorities()
        {
            return context.Priorities.ToList();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
