﻿using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        public List<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destiation);
        List<Flight> OrderedDurationFlights();
        List<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<String,Flight>> DestinationGroupedFlights();
        List<Flight> GetFlightByDate(DateTime dateDepart);
        public int GetTicketNbre(Flight flight);
    }
}
