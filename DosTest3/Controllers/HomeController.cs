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
using System.Net.Http;

namespace DosTest3.Controllers
{
    public class HomeController : Controller
    {
        FileModel fileModel;
        ApplicationContext _context;
        IWebHostEnvironment _appEnvironment;

        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
       /* public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }*/

        /*public IActionResult Index()
        {
            return View(_context.Files.ToList());
        }*/

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

        public string Coding(string file, string typeCoding)
        {
            return file;
          //file typeCoding
        }

        public string Win1251ToUTF8(string source)
        {
            string text = "";

            using (StreamReader reader = new StreamReader("file.txt", Encoding.GetEncoding(1251) ))
            using (StreamWriter writer = new StreamWriter("file1.txt", false, Encoding.UTF8) )
            {
               
            }

            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] utf8Bytes = win1251.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(utf8, win1251, utf8Bytes);
            source = win1251.GetString(win1251Bytes);

            return source;
            //  
           
            
        }

        public string Win1251ToKoi8(string source)
        {
            string text = "";
            Encoding koi8 = Encoding.GetEncoding("KOI-8");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] koi8Bytes = koi8.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(koi8, win1251, koi8Bytes);
            source = win1251.GetString(win1251Bytes);

            return source;
        }

        public string Win1251ToCP886(string source)
        {
            string text = "";
            Encoding cp886 = Encoding.GetEncoding("CP-886");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] cp886Bytes = cp886.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(cp886, win1251, cp886Bytes);
            source = win1251.GetString(win1251Bytes);

            return source;
        }
       
        public string Koi8ToWin1251(string source)
        {
            string text = "";
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");
            Encoding koi8 = Encoding.GetEncoding("KOI-8");

            byte[] koi8Bytes = koi8.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(koi8, win1251, koi8Bytes);
            source = win1251.GetString(win1251Bytes);

            return source;
        }
        public string Koi8ToCP886(string source)
        {
            string text = "";
            Encoding cp886 = Encoding.GetEncoding("CP-886");
            Encoding koi8 = Encoding.GetEncoding("KOI-8");

            byte[] cp886Bytes = cp886.GetBytes(text);
            byte[] koi8Bytes = Encoding.Convert(koi8, koi8, cp886Bytes);
            source = koi8.GetString(koi8Bytes);

            return source;
        }
        public string Koi8ToToUTF8(string source)
        {
            string text = "";
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding koi8 = Encoding.GetEncoding("KOI-8");

            byte[] koi8Bytes = koi8.GetBytes(text);
            byte[] utf8Bytes = Encoding.Convert(koi8, utf8, koi8Bytes);
            source = utf8.GetString(utf8Bytes);

            return source;
        }

        public string CP886ToKoi8(string source)
        {
            string text = "";
            Encoding cp886 = Encoding.GetEncoding("CP-886");
            Encoding koi8 = Encoding.GetEncoding("KOI-8");
           
            byte[] koi8Bytes = koi8.GetBytes(text);
            byte[] cp886Bytes = Encoding.Convert(koi8, cp886, koi8Bytes);
            source = cp886.GetString(cp886Bytes);

            return source;
        }
        public string CP886ToWin1251(string source)
        {
            string text = "";
            Encoding cp886 = Encoding.GetEncoding("CP-886");
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] cp886Bytes = cp886.GetBytes(text);
            byte[] win1251Bytes = Encoding.Convert(cp886, win1251, cp886Bytes);
            source = win1251.GetString(win1251Bytes);

            return source;
        }
        
        public string CP886ToUTF8(string source)
        {
            string text = "";
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding cp886 = Encoding.GetEncoding("CP-886");

            byte[] cp886Bytes = cp886.GetBytes(text);
            byte[] utf8Bytes = Encoding.Convert(cp886, utf8, cp886Bytes);
            source = utf8.GetString(utf8Bytes);

            return source;
        }

        public string GetFile(path, name)
        {

            Process myProcess = new Process();
            myProcess.StartInfo.FileName = cmd.exe;
            myProcess.StartInfo.Arguments = @"/C cd " + Application.StartupPath + "/server/login & start.bat";
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            return path;

        }
    }
}
