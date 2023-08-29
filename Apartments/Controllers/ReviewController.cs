using System.Data.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Apartments.Controllers
{
    public class ReviewController : Controller
    {
        private readonly NewModelContainer modelContainer = new NewModelContainer();

        ~ReviewController() 
        {
            modelContainer.Dispose();
        }

        // GET: Review
        public ActionResult Index()
        {
            return View(modelContainer.Reviews);
        }

        // GET: Review/Details/5
        public ActionResult Details(int? id)
        {
            return CommonAction(id);
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(Review review)
        {
            Apartment apartment = modelContainer.Apartments.Find(review.ApartmentID);

            if (ModelState.IsValid && apartment != null)
            {
                modelContainer.Reviews.Add(review);
                modelContainer.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Review review = modelContainer.Reviews.Find(id);

            try
            {
                if (TryUpdateModel(review, "", new string[]
                {
                nameof(Review.ApartmentID),
                nameof(Review.Content),
                }))
                {
                    modelContainer.Entry(review).State = EntityState.Modified;
                    modelContainer.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return View(review);
                throw;
            }

            return View(review);
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            modelContainer.Reviews.Remove(modelContainer.Reviews.Find(id));
            modelContainer.SaveChanges();

            return RedirectToAction("Index");
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Review review = modelContainer.Reviews
                .SingleOrDefault(r => r.IDReview == id);

            if (review == null)
            {
                return HttpNotFound();
            }

            return View(review);
        }
    }
}
