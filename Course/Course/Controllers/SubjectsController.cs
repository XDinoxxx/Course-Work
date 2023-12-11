using Course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    [Route("Subjects/")]
    public class SubjectsController : Controller
    {
        private readonly AddDbContext _dbContext;

        public SubjectsController(AddDbContext context)
        {
            context = _dbContext;
        }

        // GET: SubjectsController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubjectsController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectsController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubjectsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectsController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(Subjects subject)
        {
            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("TeacherPage", "Home");
        }
    }
}
