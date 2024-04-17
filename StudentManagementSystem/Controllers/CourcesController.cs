using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DataAcess.Interface;
using StudentManagementSystem.DataAcess.Repository;
using StudentManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    [Authorize]
    public class CourcesController : Controller
    {
        private readonly ICourcesInterface _courcesRepository;

        public CourcesController(ICourcesInterface courcesRepository)
        {
            _courcesRepository = courcesRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allCources = _courcesRepository.GetAllCources();
            return View(allCources);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourcesViewModel cources)
        {
            if (ModelState.IsValid)
            {
                _courcesRepository.Create(cources);
                return RedirectToAction("Index");
            }
            return View(cources);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var courceViewModel = _courcesRepository.GetCources(id);
            if (courceViewModel == null)
            {
                return NotFound();
            }
            return View(courceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourcesViewModel courcesViewModel)
        {
            if (ModelState.IsValid)
            {
                _courcesRepository.Edit(courcesViewModel);
                return RedirectToAction("Index");
            }
            return View(courcesViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var courceViewModel = _courcesRepository.GetCources(id);
            if (courceViewModel == null)
            {
                return NotFound();
            }
            return View(courceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courcesRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
