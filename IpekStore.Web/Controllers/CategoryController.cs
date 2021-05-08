using IpekStore.Web.Context;
using IpekStore.Web.Models.Entities;
using IpekStore.Web.Models.VM.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    Id = c.Id,
                    Name = c.Name,
                    Status = c.IsActive
                });
            return View(categories);
        }

        [HttpGet]
        //[AcceptVerbs("GET")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[AcceptVerbs("POST")]
        public IActionResult Create(EditCategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
                return View(categoryVM);

            _context.Categories.Add(new Category
            {
                Name=categoryVM.Name,
                IsActive=categoryVM.IsActive,
                CreateUser="admin",
                LastupUser="admin",
                CreateDate=DateTime.Now,
                LastupDate=DateTime.Now
            });
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
