using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEntityFramework.Models
{
    public class FileUploadClass
    {
        public string Name { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}