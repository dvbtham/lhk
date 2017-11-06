using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using LeHuuKhoa.Core;

namespace LeHuuKhoa.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Read(int id)
        {
            var category = _unitOfWork.Categories.Get(id, checkPublished: true);
            return View(category);
        }

        public PartialViewResult PdfPartialView()
        {
            return PartialView();
        }
        
        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)

            FileStream fs = null;
            try
            {
                fs = System.IO.File.OpenRead(fullFilePath);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

        }

        [ChildActionOnly]
        public ActionResult Categories()
        {
            var categories = _unitOfWork.Categories.GetCategories().OrderBy(x => x.DisplayOrder);
            return PartialView("_CategoryLeftSidePartial", categories);
        }
    }
}