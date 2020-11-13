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
    public class DepartmentController : Controller
    {
        private readonly CompanyContext _context;

        public DepartmentController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            return View(await _context.DepartmentModel.ToListAsync());
        }


        public async Task<IActionResult> Finance()
        {
            var companyContext = _context.EmployeeDepartmentModel.Include(e => e.Employee).ThenInclude(p => p.Person);
            return View(await companyContext.ToListAsync());
        }

        public async Task<IActionResult> HR()
        {
            var companyContext = _context.EmployeeDepartmentModel.Include(e => e.Employee).ThenInclude(p => p.Person);
            return View(await companyContext.ToListAsync());
        }

        public IActionResult Departments()
        {
            return View();
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,Department")] DepartmentModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentModel);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            return View(departmentModel);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Department")] DepartmentModel departmentModel)
        {
            if (id != departmentModel.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentModel.DepartmentId))
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
            return View(departmentModel);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.DepartmentModel
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentModel = await _context.DepartmentModel.FindAsync(id);
            _context.DepartmentModel.Remove(departmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
            return _context.DepartmentModel.Any(e => e.DepartmentId == id);
        }
    }
}
