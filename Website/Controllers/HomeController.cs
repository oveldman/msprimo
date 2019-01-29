using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Website.Models;
using Website.Models.Admin;

namespace Website.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IReader _reader;

        public HomeController(PrimoContext context)
        {
            _reader = new Reader(context);
        }
        
        public IActionResult Index(int page = 1)
        {
            if (page < 1) page = 1;
            
            var model = new StoryViewModel();
            model.Stories = _reader.GetStories(page);
            model.CurrentPage = page;
            model.TotalPages = _reader.GetTotalPages();
            return View(model);
        }

        public IActionResult Ship()
        {
            return View();
        }

        public IActionResult Crew()
        {
            return View();
        }

        public IActionResult Internship()
        {
            return View();
        }

        public IActionResult Rebuilding()
        {
            return View();
        }

        public IActionResult Beginner()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}