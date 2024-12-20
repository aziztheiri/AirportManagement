﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public int EstimatedDuration { get; set; }
        public int PlaneId { get; set; }
        [ForeignKey("PlaneId")]
        public virtual Plane Plane { get; set; }
        public string Airline { get; set; }
        [NotMapped]
        public int NbrTicket { get; set; }
        public override string? ToString()
        {
            return "Flight Date : " + FlightDate + "Destination : " + Destination + "EffectiveArrival :" + EffectiveArrival;  
        }
    }
}
