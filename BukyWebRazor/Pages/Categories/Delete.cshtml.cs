using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BukyWebRazor.Data;
using BukyWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BukyWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;

        public Category Category { get; set; }

        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id != 0 && id != null)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {

            Category obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");

        }
    }
}