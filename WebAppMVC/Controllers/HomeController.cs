using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppMVC.Models;
using WebAppMVC.Services;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FileParserService _parser;
        private readonly DbCombine _dbCombine;
        public HomeController(ILogger<HomeController> logger, FileParserService parser, DbCombine dbCombine)
        {
            _logger = logger;
            _parser = parser;
            _dbCombine = dbCombine;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddData(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
               
                    var stream = uploadedFile.OpenReadStream();
                    var dtoSet =  _parser.GetDataFrom(stream);
                if (dtoSet != null)
                    _dbCombine.FillTheDB(dtoSet);

            }

            return RedirectToAction("Index","Table");
        }
      
        public IActionResult Charts()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}