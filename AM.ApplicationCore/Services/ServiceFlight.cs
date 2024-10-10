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

       /* public List<DateTime> GetFlightDates(string destination)
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

        }*/
      
        public List<DateTime> GetFlightDates(string destination)
        {
            var query1 = from f in Flights
                         where f.Destination == destination
                         select f.FlightDate;
            var query2 = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            return query1.ToList();
        }

        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights
                   .Where(flight => flight.Plane == plane)
                   .Select(flight => new { flight.FlightDate, flight.Destination });
                   
            var flightDetails2 = from f in Flights
                                 where f.Plane == plane
                                 select new
                                 {
                                     f.FlightDate,
                                     f.Destination
                                 };

            foreach (var f in flightDetails)
            {
                Console.WriteLine("Flight date " + f.FlightDate + "Flight Destination" + f.FlightDate);
            }
        }
      public  int ProgrammedFlightNumber(DateTime startDate)
        {
            var query1 = Flights
                         .Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7)
                         .Count();
            var query2 = (from f in Flights
                          where DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays <= 7
                          select f).Count();

            return query1;         
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

