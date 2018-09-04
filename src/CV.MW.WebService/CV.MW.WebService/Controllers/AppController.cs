using GraphQL.Server.Transports.AspNetCore.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.MW.WebService.Controllers
{
    [EnableCors("AllowAllOrigins")]
    public class AppController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/app.cshtml");
        }   
    }
}
