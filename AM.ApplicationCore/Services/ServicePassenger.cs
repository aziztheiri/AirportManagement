﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePassenger : Service<Passenger>,IServicePassenger
    {
        private IUnitOfWork unitOfWork;

        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }
    }
}
