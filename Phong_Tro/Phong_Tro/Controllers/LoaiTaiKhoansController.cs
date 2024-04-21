using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phong_Tro.Models;

namespace Phong_Tro.Controllers
{
    public class LoaiTaiKhoansController : Controller
    {
        private readonly PhongTroContext _context;

        public LoaiTaiKhoansController(PhongTroContext context)
        {
            _context = context;
        }

        // GET: LoaiTaiKhoans
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiTaiKhoans.ToListAsync());
        }

        // GET: LoaiTaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoan = await _context.LoaiTaiKhoans
                .FirstOrDefaultAsync(m => m.LoaiTk == id);
            if (loaiTaiKhoan == null)
            {
                return NotFound();
            }

            return View(loaiTaiKhoan);
        }

        // GET: LoaiTaiKhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiTk,TenTk")] LoaiTaiKhoan loaiTaiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiTaiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiTaiKhoan);
        }

        // GET: LoaiTaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoan = await _context.LoaiTaiKhoans.FindAsync(id);
            if (loaiTaiKhoan == null)
            {
                return NotFound();
            }
            return View(loaiTaiKhoan);
        }

        // POST: LoaiTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoaiTk,TenTk")] LoaiTaiKhoan loaiTaiKhoan)
        {
            if (id != loaiTaiKhoan.LoaiTk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiTaiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiTaiKhoanExists(loaiTaiKhoan.LoaiTk))
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
            return View(loaiTaiKhoan);
        }

        // GET: LoaiTaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiTaiKhoan = await _context.LoaiTaiKhoans
                .FirstOrDefaultAsync(m => m.LoaiTk == id);
            if (loaiTaiKhoan == null)
            {
                return NotFound();
            }

            return View(loaiTaiKhoan);
        }

        // POST: LoaiTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiTaiKhoan = await _context.LoaiTaiKhoans.FindAsync(id);
            if (loaiTaiKhoan != null)
            {
                _context.LoaiTaiKhoans.Remove(loaiTaiKhoan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiTaiKhoanExists(int id)
        {
            return _context.LoaiTaiKhoans.Any(e => e.LoaiTk == id);
        }
    }
}
