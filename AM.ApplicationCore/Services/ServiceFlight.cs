using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> result = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    result.Add(flight.FlightDate);
                }
            }
            for (var i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    result.Add(Flights[i].FlightDate);
                }
            }
            return result;

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    
                        foreach (var flight in Flights)
                        {
                            if (flight.Destination.Equals(filterValue))
                            {
                                Console.WriteLine(flight.ToString());   
                            }
                        }
                        break;
                    
                case "FlightDate":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.FlightDate.ToString().Equals(filterValue))
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                    }
                case "EffectiveArrival":
                    {
                        foreach (var flight in Flights)
                        {
                            if (flight.EffectiveArrival.ToString().Equals(filterValue))
                            {
                                Console.WriteLine(flight.ToString());
                            }
                        }
                        break;
                    }
                default: Console.WriteLine("Invalid Filter Type");
                    break;
            }
        }
    }
}

