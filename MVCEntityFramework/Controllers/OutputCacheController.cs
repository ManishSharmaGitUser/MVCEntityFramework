using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class OutputCacheController : Controller
    {
        // GET: OutputCache
        [OutputCache(Duration = 10, Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult GetDate()
        {
            return View();
        }
    }
}