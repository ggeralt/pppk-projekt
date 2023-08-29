﻿using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web;
using System.Collections.Generic;

namespace Apartments.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly NewModelContainer modelContainer = new NewModelContainer();

        ~ApartmentController()
        {
            modelContainer.Dispose();
        }

        // GET: Apartment
        public ActionResult Index()
        {
            return View(modelContainer.Apartments);
        }

        // GET: Apartment/Details/5
        public ActionResult Details(int? id)
        {
            return CommonAction(id);
        }

        // GET: Apartment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartment/Create
        [HttpPost]
        public ActionResult Create(Apartment apartment, IEnumerable<HttpPostedFileBase> files, string reviewContent)
        {
            if (ModelState.IsValid)
            {
                apartment.UploadedFiles = new List<UploadedFile>();
                apartment.Reviews = new List<Review>();
                AddFiles(apartment, files);
                AddReview(apartment, reviewContent);

                modelContainer.Apartments.Add(apartment);
                modelContainer.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Apartment/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Apartment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            Apartment apartment = modelContainer.Apartments.Find(id);

            if (TryUpdateModel(apartment, "", new string[]
            {
                nameof(Apartment.Address),
                nameof(Apartment.City),
                nameof(Apartment.Contact),
                nameof(Apartment.UploadedFiles) // newly added
            }))
            {
                AddFiles(apartment, files);

                modelContainer.Entry(apartment).State = EntityState.Modified;
                modelContainer.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(apartment);
        }

        // GET: Apartment/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Apartment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            modelContainer.UploadedFiles
                .RemoveRange(modelContainer.UploadedFiles
                    .Where(f => f.ApartmentID == id));
            modelContainer.Reviews
                .RemoveRange(modelContainer.Reviews
                    .Where(r => r.ApartmentID == id));
            modelContainer.Apartments
                .Remove(modelContainer.Apartments
                    .Find(id));
            modelContainer.SaveChanges();

            return RedirectToAction("Index");
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Apartment apartment = modelContainer.Apartments
                .Include(a => a.UploadedFiles)
                .Include(p => p.Reviews)
                .SingleOrDefault(a => a.IDApartment == id);

            if (apartment == null)
            {
                return HttpNotFound();
            }

            return View(apartment);
        }

        private void AddFiles(Apartment apartment, IEnumerable<HttpPostedFileBase> files)
        {
            foreach(var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var picture = new UploadedFile
                    {
                        Name = file.FileName,
                        ContentType = file.ContentType
                    };

                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }

                    apartment.UploadedFiles.Add(picture);
                }
            }
        }

        private void AddReview(Apartment apartment, string reviewContent)
        {
            if (string.IsNullOrEmpty(reviewContent))
            {
                return;
            }

            apartment.Reviews.Add(new Review()
            {
                Content = reviewContent,
                ApartmentID = apartment.IDApartment
            });
        }
    }
}
