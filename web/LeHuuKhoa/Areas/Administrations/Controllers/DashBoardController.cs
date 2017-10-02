using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeHuuKhoa.Areas.Administrations.Controllers
{
    public class DashBoardController : BaseController
    {
        // GET: Administrations/DashBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}