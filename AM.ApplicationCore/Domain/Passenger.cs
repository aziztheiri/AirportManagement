using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "First Name : " + FirstName + "Last Name :" + LastName + "BirthDate : " + BirthDate;
        }
        public bool CheckProfile(string nom , string prenom)
        {
            return this.FirstName == nom && this.LastName == prenom;
        }
        public bool CheckProfile(string nom, string prenom,string email)
        {
            return this.FirstName == nom && this.LastName == prenom && this.EmailAddress == email;
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
