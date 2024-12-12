using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        public List<Passenger> GetPassenger (Plane plane);
        public IEnumerable<IGrouping<int,Flight>> GetFlights (int n);
        public Boolean IsAvailablePlane(Flight flight,int n);
        public void DeletePlanes();
        public int GetFlightNbre(Plane plane);
    }
}
