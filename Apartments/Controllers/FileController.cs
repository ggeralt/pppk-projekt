using System.Web.Mvc;

namespace Apartments.Controllers
{
    public class FileController : Controller
    {
        private readonly ModelContainer modelContainer = new ModelContainer();

        ~FileController()
        {
            modelContainer.Dispose();
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var uploadedFile = modelContainer.UploadedFiles.Find(id);

            return File(uploadedFile.Content, uploadedFile.ContentType);
        }

        public ActionResult Delete(int id)
        {
            modelContainer.UploadedFiles.Remove(modelContainer.UploadedFiles.Find(id));
            modelContainer.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}