using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace AM.UI.WEB.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IServicePassenger servicePassenger;

        public PassengerController(IServicePassenger servicePassenger)
        {
            this.servicePassenger = servicePassenger;
        }

        // GET: PassengerController
        public ActionResult Index()
        {
            return View(servicePassenger.GetMany().ToList());
        }

        // GET: PassengerController/Details/5
        public ActionResult Details(int id)
        {
            var passenger = servicePassenger.GetById(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
         
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger passenger)
        {
            try
            {
                servicePassenger.Add(passenger);
                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var passenger = servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Passenger passenger)
        {
            try
            {
                servicePassenger.Update(passenger);
                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var passenger = servicePassenger.GetById((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var passenger = servicePassenger.GetById(id);
                servicePassenger.Delete(passenger);
                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
