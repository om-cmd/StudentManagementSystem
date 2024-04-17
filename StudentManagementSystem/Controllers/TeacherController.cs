using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    [Authorize]

    public class TeacherController : Controller
    {
       
        private readonly ITeacherInterface _tb;
        public TeacherController( ITeacherInterface tb)
        {
            _tb = tb;
        }
        [HttpGet]   
        public IActionResult Index()
        {
            var allteacher = _tb.GetAllTeachers();
            return View(allteacher);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _tb.Create(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {       
            var teacher = _tb.GetTeacher(id);

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(Teacher teacher)
        {

            if (ModelState.IsValid)
            {
                _tb.Create(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {

            var teacher = _tb.GetTeacher(id);

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConform(int id)
        {
          
            _tb.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
