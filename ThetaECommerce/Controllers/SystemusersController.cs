using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThetaECommerce.Models;

namespace ThetaECommerce.Controllers
{
    public class SystemusersController : Controller
    {
        private readonly thetaecommercedbContext _context;

        public SystemusersController(thetaecommercedbContext context)
        {
            _context = context;
        }

        // GET: Systemusers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Systemusers.ToListAsync());
        }

        // GET: Systemusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemusers = await _context.Systemusers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemusers == null)
            {
                return NotFound();
            }

            return View(systemusers);
        }

        // GET: Systemusers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Systemusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Username,Password,ProfilePicture,Contact,Email,Role,Status,Gender,Address,Extras,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Systemusers systemusers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemusers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemusers);
        }

        // GET: Systemusers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemusers = await _context.Systemusers.FindAsync(id);
            if (systemusers == null)
            {
                return NotFound();
            }
            return View(systemusers);
        }

        // POST: Systemusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Username,Password,ProfilePicture,Contact,Email,Role,Status,Gender,Address,Extras,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] Systemusers systemusers)
        {
            if (id != systemusers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemusers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemusersExists(systemusers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(systemusers);
        }

        // GET: Systemusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemusers = await _context.Systemusers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemusers == null)
            {
                return NotFound();
            }

            return View(systemusers);
        }

        // POST: Systemusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemusers = await _context.Systemusers.FindAsync(id);
            _context.Systemusers.Remove(systemusers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemusersExists(int id)
        {
            return _context.Systemusers.Any(e => e.Id == id);
        }



[HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(Systemusers U)
        {
            Systemusers _U= _context.Systemusers.Where(abc => abc.Username == U.Username && abc.Password == U.Password).FirstOrDefault<Systemusers>();

            if (_U != null)
            {
                HttpContext.Session.SetString("Username",_U.Username);
                HttpContext.Session.SetString("Role", _U.Role);

                Response.Cookies.Append("LLT", DateTime.Now.ToString());
                return RedirectToAction(nameof(Index), "Categories");
            }
            else
            {
                ViewBag.Message = "Invalid Details";
                return View();
            }




            return View();
        }
    }
}
