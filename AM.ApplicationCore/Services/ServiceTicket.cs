using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceTicket : Service<Ticket>,IServiceTicket
    {
        private IUnitOfWork unitOfWork;

        public ServiceTicket(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }
    }
}
