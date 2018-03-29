using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestePratico.Data;
using TestePratico.Models;

namespace TestePratico.Controllers
{
    public class TrainingController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        // Constructor
        public TrainingController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var user = await _userManager.GetUserAsync(User);
                var applicationDbContext = _context.Trainings
                    .Include(t => t.Player)
                    .Include(a => a.Coach)
                    .Where(a => a.CoachID == user.Id);

                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                //Utiliza expreção lambda para obter apenas treinos referentes ao Id do usuario logado
                var user = await _userManager.GetUserAsync(User);
                var applicationDbContext = _context.Trainings
                    .Include(t => t.Player)
                    .Include(a => a.Coach)
                    .Where(x => x.PlayerID == user.Id);

                return View(await applicationDbContext.ToListAsync());
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(t => t.Player)
                .Include(a => a.Coach)
                .SingleOrDefaultAsync(m => m.TrainingID == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Coach"] = new SelectList(_userManager.GetUsersInRoleAsync("Admin").Result, "Id", "Name");
            ViewData["Player"] = new SelectList(_userManager.GetUsersInRoleAsync("User").Result, "Id", "Name");
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingID,Time,Date,PlayerID")] Training training)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                training.CoachID = user.Id;
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Coach"] = new SelectList(_userManager.GetUsersInRoleAsync("Admin").Result, "Id", "Name", training.CoachID);
            ViewData["Player"] = new SelectList(_userManager.GetUsersInRoleAsync("User").Result, "Id", "Name", training.PlayerID);
            return View(training);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings.SingleOrDefaultAsync(m => m.TrainingID == id);
            if (training == null)
            {
                return NotFound();
            }
            ViewData["Coach"] = new SelectList(_userManager.GetUsersInRoleAsync("Admin").Result, "Id", "Name", training.CoachID);
            ViewData["Player"] = new SelectList(_userManager.GetUsersInRoleAsync("User").Result, "Id", "Name", training.PlayerID);
            return View(training);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingID,Time,Date,PlayerID")] Training training)
        {
            if (id != training.TrainingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    training.CoachID = user.Id;
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.TrainingID))
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
            ViewData["Coach"] = new SelectList(_userManager.GetUsersInRoleAsync("Admin").Result, "Id", "Name", training.CoachID);
            ViewData["Player"] = new SelectList(_userManager.GetUsersInRoleAsync("User").Result, "Id", "Name", training.PlayerID);
            return View(training);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(t => t.Player)
                .Include(a => a.Coach)
                .SingleOrDefaultAsync(m => m.TrainingID == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training = await _context.Trainings.SingleOrDefaultAsync(m => m.TrainingID == id);
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.TrainingID == id);
        }
    }
}
