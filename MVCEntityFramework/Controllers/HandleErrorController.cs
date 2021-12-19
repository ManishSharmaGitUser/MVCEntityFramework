using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    //using at Controller level

        //To use this HandleError attribute Globally
         //we added some code in Global.asax go and refer
    [HandleError]
    public class HandleErrorController : Controller
    {
        // GET: HandleError
        //before using this HandleError Attribute we added Error.cshtml view page in Shared Folder and in webconfig file we 
        //added customerror mode set to on
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception("This is a Exception");
        }

        public ActionResult About()
        {
            throw new Exception("This is a Exception");
        }
    }
}