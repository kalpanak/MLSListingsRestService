using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLSListingsRestService.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
          //  return RedirectToAction("Index", "Help");
            return View();
        }
    }
}
