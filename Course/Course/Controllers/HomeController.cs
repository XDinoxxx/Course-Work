using Course.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Course.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AddDbContext _context;
        public HomeController(ILogger<HomeController> logger, AddDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult GoToAuto()
        {
            return View("~/Views/User/Autorithation.cshtml");
        }
        public IActionResult GoToReg()
        {
            return View("~/Views/User/Index.cshtml");
        }

        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult TeacherPage()
        {
            var subjects = _context.Subjects.ToList();
            return View(subjects);
        }

        public IActionResult StudentPage()
        {
            int studentId = (int)TempData["studentId"];

            List<Gradebooks> gradebooksList = _context.GetGradebooks(studentId);
            List<Subjects> subjectsList = _context.GetSubjects();

            var viewModel = new Mixed 
            {
                gradebooks = gradebooksList,
                subjects = subjectsList
            };

            return View(viewModel);
        }
        public IActionResult ParentPage()
        {
            int parent_id = (int)TempData["parentId"];
            /*var child_id = _context.Parents.Where(p => p.parent_id == parent_id).Select(p => p.child_id).ToList();
            var grades = _context.Gradebooks.Where(g => child_id.Contains(g.student_id)).ToList();*/
            var gradebooksWithChildName = from parent in _context.Parents
                                          where parent.parent_id == parent_id
                                          join child in _context.Users on parent.child_id equals child.id
                                          join gradebook in _context.Gradebooks on child.id equals gradebook.student_id into childGrades
                                          select new ChildrensData
                                          {
                                              name = child.name + " " + child.surname,
                                              grades = childGrades.Select(grade => new Gradebooks{ grade = grade.grade, homework_grade = grade.homework_grade })
                                          };

            return View(gradebooksWithChildName.ToList());
        }
    }
}
