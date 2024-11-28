using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class PlaneController : Controller
    {
        private readonly IServicePlane servicePlane;

        public PlaneController(IServicePlane servicePlane)
        {
            this.servicePlane = servicePlane;
        }

        // GET: PlaneController
        public ActionResult Index()
        {
            return View(servicePlane.GetMany().ToList());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            var plane = servicePlane.GetById(id);
            if(plane == null)
            {
                return NotFound();
            }
            return View(plane);
        }

        // GET: PlaneController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane)
        {
            try
            {
               servicePlane.Add(plane);
                servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plane = servicePlane.GetById((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            ViewBag.PlaneType = new SelectList(Enum.GetNames(typeof(PlaneType)),plane.PlaneType);
            return View(plane);
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plane plane)
        {
            try
            {
                servicePlane.Update(plane);
                servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plane = servicePlane.GetById((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            return View(plane);
            
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var plane = servicePlane.GetById(id);
                servicePlane.Delete(plane);
                servicePlane.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
