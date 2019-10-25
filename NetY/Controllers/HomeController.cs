using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetY.Models;
using Ylp.Common;

namespace NetY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ApplicationDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
             ViewBag.Session=  HttpContext.Session.GetString("CurrentUser");
            return View(await _context.News.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.ID == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        #region 注册登录

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("ID,UserName,PassWord,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                user.CreateDate = DateTime.Now;
                user.IsPost = false;
                user.PassWord = MD5Helper.Get32MD5One(user.PassWord);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([Bind("ID,UserName,PassWord")] User user)
        {
            if (ModelState.IsValid)
            {
                user.PassWord = MD5Helper.Get32MD5One(user.PassWord);
                User users=  _context.User.Where(e=>e.UserName==user.UserName).Where(e=>e.PassWord==user.PassWord).FirstOrDefault();

                if (users != null)
                {
                    HttpContext.Session.SetString("CurrentUser", user.UserName);

                    return RedirectToAction(nameof(Index),"Account");
                }
            }

            return View(user);
        }

        public bool IsLogin()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
            {
                return true;
            }

            return false;
        }

        #endregion



        #region Post

        [HttpPost]
        public void PostImage([FromBody] string value)
        {
            Response.HttpContext.ToString();  
        }

        [HttpPost]
        public async Task<byte[]> Image2()
        {
            using (var ms = new MemoryStream(2048))
            {
                await Request.Body.CopyToAsync(ms);
                byte[] buffer = ms.ToArray();

                Stream stream = null;
                stream = HttpContext.Request.Body;
                stream.Read(buffer, 0, buffer.Length);

                string webRootPath = _hostingEnvironment.WebRootPath;

                //var filePath = @"\Upload\" + Guid.NewGuid().ToString() + ".jpg";

                var filePath = @"\F\netcore\zwy\NetY\NetY\wwwroot\Files\Pictures\" + Guid.NewGuid().ToString() + ".jpg";
                FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                fs.Dispose();

                return ms.ToArray();
            }
        }


        #endregion
    }
}
