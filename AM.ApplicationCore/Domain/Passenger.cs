using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [MaxLength(25,ErrorMessage ="FirstName must be 25 caracters max ")]
        [MinLength(3,ErrorMessage ="FirstName must have a minimum of 3 caracters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[0-9]{8}$",ErrorMessage ="Invalid Phone Number!")]
        public int? TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

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
