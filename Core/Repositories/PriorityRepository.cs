using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        public TicketDbContext context;

        public PriorityRepository()
        {
            context = new TicketDbContext();
        }

        public PriorityRepository(TicketDbContext context)
        {
            this.context = context;
        }

        public Priority Add(Priority priority)
        {
            return context.Priorities.Add(priority);
        }

        public List<Priority> GetAll()
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
