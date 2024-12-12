using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType
    {
        Boing,Airbus
    }
    public class Plane
    {
     
        public int PlaneId { get; set; }
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        [NotMapped]
        public int NbrVols { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
   /*     public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }
*/
        public override string? ToString()
        {
            return "Plane Type : " + PlaneType + "ManufactureDate : " + ManufactureDate + "Capacity : " + Capacity;
        }
    }
}
