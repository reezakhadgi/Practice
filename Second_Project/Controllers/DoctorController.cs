using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Second_Project.Models;
using Second_Project.Viewmodels;

namespace Second_Project.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly NarayaniContext _context;
        public DoctorController(NarayaniContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();
        }

        // POST: Doctor/AddDoctor
        [HttpPost]
        public IActionResult AddDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = new Doctor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Specification = model.Specification,
                    Qualification = model.Qualification,
                    NMC_Number = model.NMC_Number
                };

                // Add the new doctor to the database
                _context.Doctors.Add(doctor);
                _context.SaveChanges();


                // Redirect to another action or show success message.
                return RedirectToAction("Index", "Dashboard");
            }

            return View(model); // Re-display form with validation errors if not valid.
        }
        [HttpPost]
        public IActionResult DeleteDoctor(int id)
        {
            // Find the doctor by ID
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
            {
                return NotFound();
            }

            // Remove the doctor from the database
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            // Redirect to the Index (dashboard) after deletion
            return RedirectToAction("Index","Dashboard");
        }
        [HttpGet]
        public IActionResult EditDoctor(int id)
        {
            // Find the doctor by ID
            var doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound();
            }
          
            // Return the edit view with the existing doctor's details
            return View(doctor);
        }

        // POST: Dashboard/EditDoctor/{id}
        [HttpPost]
        public IActionResult EditDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                // Update the doctor's details in the context
                _context.Doctors.Update(doctor);
                _context.SaveChanges();

                // Redirect to the dashboard after update
                return RedirectToAction("Index", "Dashboard");
            }

            // If model state is invalid, return the form with validation errors
            return View(doctor);
        }
    }
}




