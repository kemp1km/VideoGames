using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGames.Data;
using VideoGames.Models;

namespace VideoGames.Controllers
{
    public class MyGamesController : Controller
    {
        private readonly VideoGamesContext _context;


        public MyGamesController(VideoGamesContext context)
        {
            _context = context;
        }

        // GET: MyGames
        public async Task<IActionResult> Index()
        {
            int GenreCount = _context.Genre.Count();
            if (GenreCount > 0)//must have genre to create a game review
            {
                var videoGamesContext = _context.MyGames.Include(m => m.Game);
                return View(await videoGamesContext.ToListAsync());
            }
            else
            {
                return Redirect("/Genres/Index");
            }
        }

        // GET: MyGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGames = await _context.MyGames
                .Include(m => m.Game)
                .FirstOrDefaultAsync(m => m.MyGamesId == id);
            if (myGames == null)
            {
                return NotFound();
            }

            return View(myGames);
        }

        // GET: MyGames/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Game, "GameId", "GameId");
            return View();
        }

        // POST: MyGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyGamesId,GameID,ReviewGrade,Review,ReviewDate")] MyGames myGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameId", "GameId", myGames.GameID);
            return View(myGames);
        }

        // GET: MyGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGames = await _context.MyGames.FindAsync(id);
            if (myGames == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Game, "GameId", "GameId", myGames.GameID);
            return View(myGames);
        }

        // POST: MyGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyGamesId,GameID,ReviewGrade,Review,ReviewDate")] MyGames myGames)
        {
            if (id != myGames.MyGamesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyGamesExists(myGames.MyGamesId))
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
            ViewData["GameID"] = new SelectList(_context.Game, "GameId", "GameId", myGames.GameID);
            return View(myGames);
        }

        // GET: MyGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGames = await _context.MyGames
                .Include(m => m.Game)
                .FirstOrDefaultAsync(m => m.MyGamesId == id);
            if (myGames == null)
            {
                return NotFound();
            }

            return View(myGames);
        }

        // POST: MyGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myGames = await _context.MyGames.FindAsync(id);
            _context.MyGames.Remove(myGames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyGamesExists(int id)
        {
            return _context.MyGames.Any(e => e.MyGamesId == id);
        }
    }
}
