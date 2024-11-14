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

        /*  private IGenericRepository<Plane> _repository;

 public ServicePlane(IGenericRepository<Plane> repository)
 {
     _repository = repository;
 }*/

     
    }
}
