using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext() : base("TicketingConnectionString")
        {
            Database.SetInitializer(new TicketDbContextInitializer());
            Database.Initialize(true);
        }

        public DbSet<Priority> Priorities { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
    }
}
