using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using StudentManagementSystem.Data;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{
    [Authorize]

    public class StudentController : Controller
    {
        private readonly IStudentInterface _tr;

        public StudentController(IStudentInterface db)
        {
            _tr = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allstudents = _tr.GetAllStudents();
            return View(allstudents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create( StudentViewModel student)
        {

            
            if (ModelState.IsValid)
            {
                _tr.Create(student);
                return View("Index");

            }
            return View(student);
           
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var studentViewModel = _tr.GetStudent(id);
            if (studentViewModel != null)
            {
                return View(studentViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
               
                _tr.Edit(studentViewModel);
                return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var student = _tr.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConform(int id)
        {
            _tr.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
