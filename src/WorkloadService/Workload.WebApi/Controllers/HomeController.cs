using AIHR.Models;
using Workload.WebApi.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Workload.WebApi.Interfaces;

namespace Workload.WebApi.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Error()
        {
            var model = new ErrorViewModel()
            {
                Message = HttpContext.Session.GetString("Message"),
                StatusCode = (int)HttpContext.Session.GetInt32("StatusCode")
            };
            HttpContext.Response.StatusCode = model.StatusCode;
            return View(model);
        }
    }
}
