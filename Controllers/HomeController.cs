using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using KnowledgeBase.Models;

namespace KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IKnowledgeBaseService _knowledgeBaseService;
        
        public HomeController(IHostingEnvironment hostingEnvironment, IKnowledgeBaseService knowledgeBaseService)
        {
            _hostingEnvironment = hostingEnvironment;
            _knowledgeBaseService = knowledgeBaseService;
        }

        public IActionResult Index()
        {                    
            ViewBag.KnowledgeBases = _knowledgeBaseService.GetKnowledgeBases($"{_hostingEnvironment.WebRootPath}\\Docs");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
