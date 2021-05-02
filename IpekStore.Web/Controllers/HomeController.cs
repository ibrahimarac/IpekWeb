
using IpekStore.Web.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Controllers
{
    public class HomeController : Controller
    {
        IpekContext _context;
        public HomeController(IpekContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

    }
}
