using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        private readonly IServiceFlight serviceFlight;
private readonly IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight,IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            List<Flight> flights = new List<Flight>();

            if (dateDepart == null)
            {
                flights = serviceFlight.GetMany().ToList();
            }
            else
            {
                flights = serviceFlight.GetFlightByDate((DateTime)dateDepart);
            }
            foreach (Flight item in flights)
            {
                item.NbrTicket = serviceFlight.GetTicketNbre(item);

            }
            return View(flights);
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            var flight = serviceFlight.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }
        public ActionResult _Details(int id)
        {
            var flight = serviceFlight.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return PartialView(flight);
        }
        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(servicePlane.GetMany(), "PlaneId","PlaneId");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile AirlineImage)
        {
            try
            {
                if (AirlineImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", AirlineImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    AirlineImage.CopyTo(stream);
                    flight.Airline = AirlineImage.FileName;
                }
                serviceFlight.Add(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = serviceFlight.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            ViewBag.PlaneId = new SelectList(servicePlane.GetMany(), "PlaneId", "PlaneId");

            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight, IFormFile AirlineImage)
        {
            try
            {
                if (AirlineImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", AirlineImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    AirlineImage.CopyTo(stream);
                    flight.Airline = AirlineImage.FileName;
                }
                serviceFlight.Update(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = serviceFlight.GetById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var flight = serviceFlight.GetById(id);
                serviceFlight.Delete(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
