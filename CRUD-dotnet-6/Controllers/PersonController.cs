using CRUD_dotnet_6.Data;
using CRUD_dotnet_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_dotnet_6.Controllers
{
    public class PersonController : Controller
    {
        private readonly PeronDbContext _context;

        public PersonController(PeronDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<PersonModel> persons = _context.GetAllPersons();
            return View("PersonList", persons);
        }

        public ActionResult Create()
        {
            return View("CreatePerson");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonModel person)
        {
            try
            {
                _context.AddPerson(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            PersonModel person = _context.GetPersonById(id);
            return View("EditPerson", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(PersonModel model)
        {
            try
            {
                _context.EditPerson(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PersonModel person  = _context.GetPersonById(id);

            return View("DeletePerson", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _context.DeletePersonById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
