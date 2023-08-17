using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Todo.DAO;
using Todo.Models;

namespace Todo.Controllers
{
    public class ItemController : Controller
    {
        private static readonly ICosmosDbService cosmosDbService = CosmosDbServiceProvider.CosmosDbService;

        // GET: Item
        public async Task<ActionResult> Index()
        {
            return View(await cosmosDbService.GetItemsAsync("SELECT * FROM Item"));
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(string id)
            => await ShowItem(id);

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public async Task<ActionResult> Create(Item item)
        {
            if (ModelState.IsValid)
            {
                item.Id = Guid.NewGuid().ToString();
                await cosmosDbService.AddItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Item/Edit/5
        public async Task<ActionResult> Edit(string id)
            => await ShowItem(id);

        // POST: Item/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                await cosmosDbService.UpdateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<ActionResult> Delete(string id)
            => await ShowItem(id);

        // POST: Item/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Item item)
        {
            await cosmosDbService.DeleteItemAsync(item);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> ShowItem(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var item = await cosmosDbService.GetItemAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}
