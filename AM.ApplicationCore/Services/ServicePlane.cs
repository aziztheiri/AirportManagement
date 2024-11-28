using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane> , IServicePlane 
    {
        private IUnitOfWork unitOfWork;

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            
            this.unitOfWork = unitOfWork;
        }

        public void DeletePlanes()
        {
          var list =  GetMany(p => DateTime.Now.Year - p.ManufactureDate.Year >= 10);
            foreach (var plane in list)
            {
                Delete(plane);
            }
            Commit();
        }

        public IEnumerable<IGrouping<int, Flight>> GetFlights(int n)
        {
            return GetMany().OrderByDescending(p=>p.PlaneId).Take(n)
                .SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate)
                .GroupBy(f=>f.Plane.PlaneId);
        }

        public List<Passenger> GetPassenger(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets)
                .Select(t=>t.Passenger).ToList();
           
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
            int capacity = Get(p => p.Flights.Contains(flight) == true).Capacity;
            int nbPassenger = flight.Tickets.Count;
            return capacity >= nbPassenger + n;
        }

        /*  private IGenericRepository<Plane> _repository;

 public ServicePlane(IGenericRepository<Plane> repository)
 {
     _repository = repository;
 }*/


    }
}
