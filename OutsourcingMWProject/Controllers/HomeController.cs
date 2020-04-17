using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutsourcingMWProject.Models;
using OutsourcingMWProject.Tools;

namespace OutsourcingMWProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PDFGenerator()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public FileResult CreatePDF(string PDFName)
        {
            PDF pdf = new PDF();
            pdf.CreatePDF(PDFName);

            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/" + pdf.fileName, FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }
    }
}
