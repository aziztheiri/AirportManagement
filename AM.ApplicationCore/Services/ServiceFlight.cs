using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        private IUnitOfWork unitOfWork;

        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }

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

        public double DurationAverage(string destiation)
        {
            var query1 = (from f in Flights
                         where f.Destination.Equals(destiation)
                         select f.EstimatedDuration).Average();
            var query2 = Flights.Where(f => f.Destination.Equals(destiation)).Select(f => f.EstimatedDuration)
                .Average();
            return query1;
        }

        public List<Flight> OrderedDurationFlights()
        {
            var query1 = from f in Flights
                         orderby f.EstimatedDuration descending
                         select f;
            var query2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return query1.ToList();
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var query1 = (from p in flight.Passengers.OfType<Traveller>()
                         orderby p.BirthDate
                         select p).Take(3);
            var query2 = flight.Passengers.OfType<Traveller>().OrderBy(p=>p.BirthDate).Take(3);
            return query1.ToList();
                         
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query1 = from f in Flights
                         group f by  f.Destination;
            var query2 = Flights.GroupBy(f => f.Destination);
            foreach(var grouped in query1)
            {
                Console.WriteLine("Destination : " + grouped.Key);
                foreach(var f in grouped)
                {
                    Console.WriteLine("Decollage : " + f.FlightDate);
                }
            }
            return query1;
        }
    }
}

