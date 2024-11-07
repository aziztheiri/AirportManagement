using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(f => new { f.PassengerFk, f.FlightFk, f.NumTicket });
            builder.HasOne<Passenger>(f => f.Passenger)
                .WithMany(p => p.Tickets)
                .HasForeignKey(f => f.PassengerFk);
            builder.HasOne<Flight>(f => f.Flight)
                      .WithMany(p => p.Tickets)
                      .HasForeignKey(f => f.FlightFk);

        }
    }
}
