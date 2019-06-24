using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using IronPdf;

namespace KnowledgeBase.Controllers
{
    public class KnowledgeBaseController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private IKnowledgeBaseService _knowledgeBaseService;

        public KnowledgeBaseController(IHostingEnvironment hostingEnvironment, IKnowledgeBaseService knowledgeBaseService)
        {
            _hostingEnvironment = hostingEnvironment;
            _knowledgeBaseService = knowledgeBaseService;
        }

        public IActionResult Index(string document)
        {
            ViewData["Title"] = document;
            ViewBag.KnowledgeBases = _knowledgeBaseService.GetKnowledgeBases($"{_hostingEnvironment.WebRootPath}\\Docs");
            ViewBag.MarkdownFiles = _knowledgeBaseService.GetMdFilesFromDirectory($"{_hostingEnvironment.WebRootPath}\\Docs\\{document}");
            ViewBag.Document = document;

            Folder rootFolder = new Folder($"{_hostingEnvironment.WebRootPath}\\Docs\\{document}");
            ViewBag.RootFolder = rootFolder;
            
            return View();
        }

        [HttpPost]
        public string FetchMarkdown([FromBody]JObject o)
        {
            string filePath = o["file"].ToString();
            string document = o["document"].ToString();

            return _knowledgeBaseService.GetMarkdown($"{_hostingEnvironment.WebRootPath}\\Docs\\{document}", filePath);
        }
        
        [HttpPost]
        public JsonResult SearchMarkdown([FromBody]JObject o)
        {
            string searchPattern = o["searchPattern"].ToString().Trim();
            string document = o["document"].ToString();

            if(string.IsNullOrEmpty(searchPattern))
                return Json(null);            

            var foundFiles = _knowledgeBaseService.SearchFor($"{_hostingEnvironment.WebRootPath}\\Docs\\{document}", searchPattern);

            return Json(foundFiles);
        }

        [HttpPost]
        public void SaveMarkdown([FromBody]JObject o)
        {
            string filePath = o["file"].ToString();
            string document = o["document"].ToString();
            string markdown = o["markdown"].ToString();

            _knowledgeBaseService.SaveMarkdown($"{_hostingEnvironment.WebRootPath}\\Docs\\{document}", filePath, markdown);
        }

        [HttpPost]
        public void CreatePdf([FromBody]JObject o)
        {
            string html = o["html"].ToString();

            if(string.IsNullOrEmpty(html))
                return;

            var Renderer = new HtmlToPdf();
            Renderer.RenderHtmlAsPdf(html, $"{_hostingEnvironment.WebRootPath}\\Docs\\").SaveAs(@"test.pdf");
        }
    }
}