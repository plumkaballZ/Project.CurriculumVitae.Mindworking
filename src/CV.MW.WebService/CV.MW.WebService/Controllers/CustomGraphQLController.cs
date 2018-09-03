using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.MW.WebService.Controllers
{
    public class CustomGraphQLController : Controller
    {
        public ActionResult Index()
        {
            return View("/Views/app.cshtml");
        }

        [HttpGet]
        public string Get()
        {
            return "service_running_x4";
        }
    }
}
