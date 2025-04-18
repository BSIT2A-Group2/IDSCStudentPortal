using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IDSCStudentPortal.Data;
using IDSCStudentPortal.Models;

namespace IDSCStudentPortal.Controllers
{
    public class StudentDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StudentDetails.Include(s => s.Course).Include(s => s.Enrollment).Include(s => s.Program).Include(s => s.Schedule).Include(s => s.Strand);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails
                .Include(s => s.Course)
                .Include(s => s.Enrollment)
                .Include(s => s.Program)
                .Include(s => s.Schedule)
                .Include(s => s.Strand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return View(studentDetail);
        }

        // GET: StudentDetails/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id");
            ViewData["ProgramId"] = new SelectList(_context.DepPrograms, "Id", "Id");
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id");
            ViewData["StrandId"] = new SelectList(_context.Strands, "Id", "Id");
            return View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnrollmentId,ProgramId,CourseId,StrandId,ScheduleId")] StudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentDetail.CourseId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", studentDetail.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.DepPrograms, "Id", "Id", studentDetail.ProgramId);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", studentDetail.ScheduleId);
            ViewData["StrandId"] = new SelectList(_context.Strands, "Id", "Id", studentDetail.StrandId);
            return View(studentDetail);
        }

        // GET: StudentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentDetail.CourseId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", studentDetail.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.DepPrograms, "Id", "Id", studentDetail.ProgramId);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", studentDetail.ScheduleId);
            ViewData["StrandId"] = new SelectList(_context.Strands, "Id", "Id", studentDetail.StrandId);
            return View(studentDetail);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnrollmentId,ProgramId,CourseId,StrandId,ScheduleId")] StudentDetail studentDetail)
        {
            if (id != studentDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDetailExists(studentDetail.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", studentDetail.CourseId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "Id", "Id", studentDetail.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.DepPrograms, "Id", "Id", studentDetail.ProgramId);
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Id", studentDetail.ScheduleId);
            ViewData["StrandId"] = new SelectList(_context.Strands, "Id", "Id", studentDetail.StrandId);
            return View(studentDetail);
        }

        // GET: StudentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetail = await _context.StudentDetails
                .Include(s => s.Course)
                .Include(s => s.Enrollment)
                .Include(s => s.Program)
                .Include(s => s.Schedule)
                .Include(s => s.Strand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return View(studentDetail);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDetail = await _context.StudentDetails.FindAsync(id);
            if (studentDetail != null)
            {
                _context.StudentDetails.Remove(studentDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDetailExists(int id)
        {
            return _context.StudentDetails.Any(e => e.Id == id);
        }
    }
}
