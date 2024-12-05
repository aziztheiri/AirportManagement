using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServiceTicket serviceTicket;
        private readonly IServicePassenger servicePassenger;
        private readonly IServiceFlight serviceFlight;

        public TicketController(IServiceTicket serviceTicket, IServicePassenger servicePassenger, IServiceFlight serviceFlight)
        {
            this.serviceTicket = serviceTicket;
            this.servicePassenger = servicePassenger;
            this.serviceFlight = serviceFlight;
        }



        // GET: TicketController
        public ActionResult Index()
        {
            return View(serviceTicket.GetMany().ToList());
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int? PassengerFK , int? FlightFK, int?  NumTicket)
        {
            if((PassengerFK == null) || (FlightFK == null) || (NumTicket == null))
            {
                return NotFound();
            }
            var ticket = serviceTicket.GetMany().FirstOrDefault(m => m.PassengerFk == PassengerFK &&
            m.FlightFk == FlightFK && m.NumTicket == NumTicket
            );
           if(ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            ViewBag.PassengerFk = new SelectList(servicePassenger.GetMany(),"Id","Id");
            ViewBag.FlightFk = new SelectList(serviceFlight.GetMany(), "FlightId", "FlightId");

            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                serviceTicket.Add(ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Edit/5
        public ActionResult Edit(int? PassengerFK, int? FlightFK, int? NumTicket)
        {

            if ((PassengerFK == null) || (FlightFK == null) || (NumTicket == null))
            {
                return NotFound();
            }
            var ticket = serviceTicket.GetMany().FirstOrDefault(m => m.PassengerFk == PassengerFK &&
            m.FlightFk == FlightFK && m.NumTicket == NumTicket
            );
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                serviceTicket.Update(ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int? PassengerFK, int? FlightFK, int? NumTicket)
        {
            if ((PassengerFK == null) || (FlightFK == null) || (NumTicket == null))
            {
                return NotFound();
            }
            var ticket = serviceTicket.GetMany().FirstOrDefault(m => m.PassengerFk == PassengerFK &&
            m.FlightFk == FlightFK && m.NumTicket == NumTicket
            );
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int PassengerFK, int FlightFK, int NumTicket)
        {
            try
            {
                var ticket = serviceTicket.GetMany().FirstOrDefault(m => m.PassengerFk == PassengerFK &&
                           m.FlightFk == FlightFK && m.NumTicket == NumTicket
                           );
                serviceTicket.Delete(ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
