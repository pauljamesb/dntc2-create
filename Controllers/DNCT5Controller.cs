using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNCT5.Data;
using Microsoft.AspNetCore.Mvc;

namespace DNCT5.Controllers
{
    public class DNCT5Controller : Controller
    {
        private readonly ApplicationDbContext _db;
        public DNCT5Controller(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Items.ToList());
        }

        // GET Create action
        public IActionResult Create()
        {
          return View();
        }

        // POST Create Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Item item)
        {
          if(ModelState.IsValid)
          {
            _db.Add(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
          }
          return View(item);
        }
    }
}
