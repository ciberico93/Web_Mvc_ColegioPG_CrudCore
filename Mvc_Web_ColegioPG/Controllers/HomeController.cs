using CRUD_COLEGIO_APP_0609.Models;
using CRUD_COLEGIO_APP_0609.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_COLEGIO_APP_0609.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAlumnoRepository<Alumno> _alumnoRepository;

        private readonly ICursoRepository<Curso> _cursoRepository;

        public HomeController(ILogger<HomeController> logger, IAlumnoRepository<Alumno> alumnoRepository, ICursoRepository<Curso> cursoRepository)
        {
            _logger = logger;

            _alumnoRepository = alumnoRepository;

            _cursoRepository = cursoRepository;
        }

        public async Task<IActionResult> Index()

        {
            var alumno = await _alumnoRepository.GetAll();

           return View(alumno);
        }

        public async Task<IActionResult> Agregar()
        {
            var curso = await _cursoRepository.GetAll();
            ViewBag.Cursos = curso;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(Alumno entity)
        {
            var alumno = await _alumnoRepository.Create(entity);
            if (alumno == null)
            {
                return View();
            }
            return RedirectToAction("Index");
        } 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}