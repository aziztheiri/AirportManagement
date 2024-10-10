using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
/*Plane plane1 = new Plane();
plane1.PlaneType = PlaneType.Airbus;
plane1.;
plane1.ManufactureDate = new DateTime(2010,12,03);
Console.WriteLine(plane1.ToString());*/
Plane plane2 = new Plane
{
    PlaneType = PlaneType.Boing,
    Capacity = 150,
    ManufactureDate = new DateTime(2015, 02, 03)
};
//Console.WriteLine(plane2);
//Plane plane3 = new Plane(200,new DateTime(2010,12,03), PlaneType.Airbus);
// Console.WriteLine(plane3);
Passenger passenger = new Passenger();
/*passenger.FirstName = "aziz";
passenger.LastName = "theiri";
passenger.EmailAddress = "test@gmail.com";
Console.WriteLine(passenger.CheckProfile("aziz", "theiri","test@gmail.com"));*/
/*Traveller traveller = new Traveller();  
Staff staff = new Staff();
passenger.PassengerType();
traveller.PassengerType();
staff.PassengerType();*/
ServiceFlight serviceFlight = new ServiceFlight();
serviceFlight.Flights = TestData.listFlights;
/*foreach (var item in serviceFlight.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
};*/
//serviceFlight.GetFlights("FlightDate", new DateTime(2022, 02, 01, 21, 10, 10).ToString());
serviceFlight.ShowFlightDetails(TestData.BoingPlane);
