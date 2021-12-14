using DosTest3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DosTest3.Controllers
{
    public class HomeController : Controller
    {

        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        */

        ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;

        public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Files.ToList());
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public string Win1251ToUTF8(string source)
        {

            string text = "Р—Р°РєР°Р· Р·РІРѕРЅРєР° С‚РµС…РЅРёС‡РµСЃРєРѕР№ РїРѕРґРґРµСЂР¶РєРё";
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] utf8Bytes = win1251.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            source = win1251.GetString(win1251Bytes);
            return source;
        }

        public string Win1251ToKoi8(string source)
        {
            return source;
        }

        public string Win1251ToCP886(string source)
        {
            return source;
        }
        /*public string Win1251ToUTF8(string source)
        {
         return source;
        }*/
        public string Koi8ToWin1251(string source)
        {
            return source;
        }
        public string Koi8ToCP886(string source)
        {
            return source;
        }
        /*public string Koi8ToToUTF8(string source)
        {
         return source;
        }*/

        public string CP886ToKoi8(string source)
        {
            return source;
        }
        public string CP886ToWin1251(string source)
        {
            return source;
        }
        /*public string CP886ToKoi8(string source)
        {
         return source;
        }*/
    }
}
