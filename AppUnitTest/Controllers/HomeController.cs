﻿using AppUnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppUnitTest.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }
        public HomeController()
        {
            repo = new ComputerRepository();
        }

        public async Task<ActionResult> Index()
        {
            var list = await repo.AllComputersAsync();
            return View(list);
        }
        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }

    }
}