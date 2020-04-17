using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        // GET: /HelloWorld/Selamat
        // Requires using System.Text.Encodings.Web;
        public string Selamat(String name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID is: {ID}");
        }

        public IActionResult Welcome(String name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
