using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        [ForeignKey("TicketType")]
        public int TicketTypeId { get; set; }
        [ForeignKey("ServiceType")]
        public int ServiceTypeId { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        [ForeignKey("Priority")]
        public int PriorityId { get; set; }
        public DateTime OpenDateTime { get; set; }
        public DateTime? CloseDateTime { get; set; }

        public virtual TicketType TicketType { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public virtual Status Status { get; set; }
        public virtual Priority Priority { get; set; }
    }
}
