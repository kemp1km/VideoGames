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
    public class GenresController : Controller
    {
        private readonly VideoGamesContext _context;
        Genre VideoGamesGenre = new Genre();
        public GenresController(VideoGamesContext context)
        {
            _context = context;
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genre.ToListAsync());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre
                .FirstOrDefaultAsync(m => m.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenreId,GameGenre,CreateDate,EditDate")] Genre genre)
        {
            bool CheckGenreName = VideoGamesGenre.GenreExistsName(_context, genre.GameGenre);

            if (CheckGenreName)
            {
                ModelState.AddModelError("GameGenre", "Genre Already Exists.");
            }

            if (ModelState.IsValid)
            {
                var currentDateTime = DateTime.Now;
                var date = currentDateTime.Date;
                genre.CreateDate = DateTime.Now.Date;//doesnt make sense to have user set these when I know what they should be
                genre.EditDate = DateTime.Now.Date;//doesnt make sense to have user set these when I know what they should be
                _context.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenreId,GameGenre,EditDate")] Genre genre)
        {
            if (id != genre.GenreId)
            {
                return NotFound();
            }

            bool CheckGenreName = VideoGamesGenre.GenreExistsName(_context ,genre.GameGenre);

            if (CheckGenreName)
            {
                ModelState.AddModelError("GameGenre", "Genre Already Exists.");
            }

            if (ModelState.IsValid)
            {                 
                try
                {
                    var currentDateTime = DateTime.Now;
                    var date = currentDateTime.Date;
                    genre.EditDate = date;//doesnt make sense to have user set these when I know what they should be, not allowing edit on create
                    _context.Update(genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.GenreId))
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
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genre
                .FirstOrDefaultAsync(m => m.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _context.Genre.FindAsync(id);
            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.GenreId == id);
        }

        //[NonAction] moved to class
        //private bool GenreExistsName(string GenreName)
        //{
        // string GenreExists =  _context.Genre.Where(x => x.GameGenre == GenreName).FirstOrDefault().ToString();
        //    if (GenreExists == string.Empty)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}
