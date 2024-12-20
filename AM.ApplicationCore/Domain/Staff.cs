﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }
        public override void PassengerType()
        {
            Console.WriteLine("I am a Staff member");
        }
    }
}
