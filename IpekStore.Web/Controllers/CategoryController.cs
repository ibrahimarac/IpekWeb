using IpekStore.Web.Context;
using IpekStore.Web.Models.Entities;
using IpekStore.Web.Models.Globals;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest("Düzenlenecek kategori numarası gönderilmedi.");
            //var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == id);
            var categoryInDb = _context.Categories.Find(id);
            if (categoryInDb == null)
                return NotFound("Belirtilen kategori numarasına karşılık gelen bir kategori bulunamadı.");

            var categoryVM = new EditCategoryVM
            {
                Id=categoryInDb.Id,
                Name=categoryInDb.Name,
                IsActive=categoryInDb.IsActive
            };

            return View(categoryVM);
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
                return View(categoryVM);
            //veritabanında yer alan orjinal bilgiler
            var categoryInDb = _context.Categories.Find(categoryVM.Id);
            //formdan gelen verilerle veritabanında yer alan kayıt güncelleniyor
            categoryInDb.Name = categoryVM.Name;
            categoryInDb.IsActive = categoryVM.IsActive;
            categoryInDb.LastupUser = "user";
            categoryInDb.LastupDate = DateTime.Now;

            _context.Categories.Update(categoryInDb);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult Delete([FromBody] JDeleteObject objToDelete)
        {
            if (!objToDelete.Id.HasValue)
                return Json(new JResult
                {
                    Status = Status.BadRequest,
                    Message = "Silinecek kategori numarası belirlenemedi."
                }); 
            var categoryInDb = _context.Categories.Find(objToDelete.Id);
            if (categoryInDb == null)
                return Json(new JResult
                {
                    Status=Status.NotFound,
                    Message="Belirtilen kategori numarasına sahip bir kategori bulunamadı."
                });

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();

            return Json(new JResult
            {
                Status = Status.Ok,
                Message = "Kategori başarıyla silindi.",
                Result=new CategoryVM { Id=categoryInDb.Id,Name=categoryInDb.Name}
            });

        }
    }
}
