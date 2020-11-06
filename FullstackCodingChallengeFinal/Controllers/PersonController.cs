using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullstackCodingChallengeFinal.Data;
using FullstackCodingChallengeFinal.Models;

namespace FullstackCodingChallengeFinal.Controllers
{
    public class PersonController : Controller
    {
        private readonly CompanyContext _context;

        public PersonController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonModel.ToListAsync());
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personModel = await _context.PersonModel
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personModel == null)
            {
                return NotFound();
            }

            return View(personModel);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,Age,SSN")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personModel);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personModel = await _context.PersonModel.FindAsync(id);
            if (personModel == null)
            {
                return NotFound();
            }
            return View(personModel);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,Age,SSN")] PersonModel personModel)
        {
            if (id != personModel.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonModelExists(personModel.PersonId))
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
            return View(personModel);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personModel = await _context.PersonModel
                .FirstOrDefaultAsync(m => m.PersonId == id);
            if (personModel == null)
            {
                return NotFound();
            }

            return View(personModel);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personModel = await _context.PersonModel.FindAsync(id);
            _context.PersonModel.Remove(personModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonModelExists(int id)
        {
            return _context.PersonModel.Any(e => e.PersonId == id);
        }
    }
}
