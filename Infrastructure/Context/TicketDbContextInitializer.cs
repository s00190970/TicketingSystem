using Infrastructure.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Infrastructure.Context
{
    public class TicketDbContextInitializer : DropCreateDatabaseIfModelChanges<TicketDbContext>
    {
        protected override void Seed(TicketDbContext context)
        {
            context.Priorities.AddRange(new List<Priority>()
            {
                new Priority("Low"),
                new Priority("Medium"),
                new Priority("High")
            });

            context.ServiceTypes.AddRange(new List<ServiceType>()
            {
                new ServiceType("Repair"),
                new ServiceType("Debug")
            });

            context.Statuses.AddRange(new List<Status>()
            {
                new Status("Waiting"),
                new Status("In Progress"),
                new Status("Testing"),
                new Status("Done")
            });

            context.TicketTypes.AddRange(new List<TicketType>()
            {
                new TicketType("Tech"),
                new TicketType("Business")
            });
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}