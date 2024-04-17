using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class ChosenCourcesController : Controller
    {
        private readonly IChosenCourcesInterface _db;

        public ChosenCourcesController(IChosenCourcesInterface db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allChosenCources = _db.GetAllChosenCources();
            return View(allChosenCources);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Students = _db.Students.ToList();
            ViewBag.Faculty = _db.Faculty.ToList();
            ViewBag.Courses = _db.Cources.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChosenCourcesViewModel chosen)
        {
            ModelState.Remove("StudentName");
            ModelState.Remove("FacultyName");
            ModelState.Remove("Title");
            if (ModelState.IsValid)
            {
                _db.Create(chosen);
                return RedirectToAction("Index");
            }

            ViewBag.Students = _db.Students.ToList();
            ViewBag.Faculty = _db.Faculty.ToList();
            ViewBag.Courses = _db.Cources.ToList();
            return View(chosen);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var chosenCources = _db.GetChosenCources(id);
            if (chosenCources == null)
            {
                return NotFound();
            }
            return View(chosenCources);
        }

        [HttpPost]
        public IActionResult Edit(ChosenCourcesViewModel chosenModel)
        {
            if (ModelState.IsValid)
            {
                var existingChosenCources = _db.GetChosenCources(chosenModel.ChosenCourcesID);
                if (existingChosenCources == null)
                {
                    return NotFound();
                }

                existingChosenCources.StudentID = chosenModel.StudentID;
                existingChosenCources.FacultyID = chosenModel.FacultyID;
                existingChosenCources.CourseID = chosenModel.CourseID;

                _db.Edit(existingChosenCources);
                return RedirectToAction("Index");
            }
            return View(chosenModel);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var chosenCources = _db.GetChosenCources(id);
            if (chosenCources == null)
            {
                return NotFound();
            }
            return View(chosenCources);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
