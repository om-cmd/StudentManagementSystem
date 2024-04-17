using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;
using StudentManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class FacultyController : Controller
    {
        private readonly IFacultyInterface _fr;

        public FacultyController(IFacultyInterface fr)
        {
            _fr = fr;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allFaculty = _fr.GetAllFaculty();
            return View(allFaculty);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacultyViewModel faculty)
        {
            if (ModelState.IsValid)
            {
                _fr.Create(faculty);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var facultyViewModel = _fr.GetFaculty(id);
            if (facultyViewModel != null)
            {
                return View(facultyViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(FacultyViewModel facultyViewModel)
        {
           if (ModelState.IsValid)
            {
                _fr.Edit(facultyViewModel);
                return RedirectToAction("Index");
            }
           return View(facultyViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var facultyViewModel = _fr.GetFaculty(id);
            if (facultyViewModel == null)
            {
                return NotFound();
            }
            return View(facultyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _fr.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
