using IpekStore.Web.Context;
using IpekStore.Web.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IpekStore.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IpekContext _context;

        public CategoryController(IpekContext context)        
        {
            _context = context;
        }
        public IActionResult List()
        {
            var categories = _context.Categories
                .Select(c => new CategoryVM
                {
                    Id=c.Id,
                    Name=c.Name,
                    Status=c.IsActive
                });
            return View(categories);
        }
    }
}
