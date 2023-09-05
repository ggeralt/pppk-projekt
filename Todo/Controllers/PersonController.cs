using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Todo.DAO;
using Todo.Models;

namespace Todo.Controllers
{
    public class PersonController : Controller
    {
        private static readonly ICosmosDbService cosmosDbService = CosmosDbServiceProvider.CosmosDbService;

        // GET: Person
        public async Task<ActionResult> Index()
        {
            return View(await cosmosDbService.GetPeopleAsync("SELECT * FROM People"));
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string id)
            => await ShowPerson(id);

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await cosmosDbService.AddPersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<ActionResult> Edit(string id)
            => await ShowPerson(id);

        // POST: Person/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await cosmosDbService.UpdatePersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<ActionResult> Delete(string id)
            => await ShowPerson(id);

        // POST: Person/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Person person)
        {
            await cosmosDbService.DeletePersonAsync(person);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> ShowPerson(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var person = await cosmosDbService.GetPersonAsync(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }
    }
}
