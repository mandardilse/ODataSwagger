using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Db;
using Models.Db.Entities;
using static Microsoft.AspNet.OData.Query.AllowedQueryOptions;

namespace Web.Controllers
{
	[ApiVersion("1.0")]
	[ODataRoutePrefix(nameof(FilmText))]
	public class FilmTextController : ODataController
	{
		private readonly sakilaContext _context;

		public FilmTextController(sakilaContext context)
		{
			_context = context;
		}

		// GET: api/FilmText
		[ODataRoute]
		[EnableQuery]
		public async Task<ActionResult<IEnumerable<FilmText>>> GetFilmText()
		{
			return await _context.FilmText.ToListAsync();
		}

		// GET: api/FilmText/5
		[ODataRoute("({id})")]
		[EnableQuery(AllowedQueryOptions = None)]
		public async Task<ActionResult<FilmText>> GetFilmText(short id)
		{
			var filmText = await _context.FilmText.FindAsync(id);

			if (filmText == null)
			{
				return NotFound();
			}

			return filmText;
		}

		// PUT: api/FilmText/5
		[ODataRoute("({id})")]
		public async Task<IActionResult> PutFilmText(short id, FilmText filmText)
		{
			if (id != filmText.FilmId)
			{
				return BadRequest();
			}

			_context.Entry(filmText).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FilmTextExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/FilmText
		[ODataRoute]
		public async Task<ActionResult<FilmText>> PostFilmText(FilmText filmText)
		{
			_context.FilmText.Add(filmText);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (FilmTextExists(filmText.FilmId))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetFilmText", new { id = filmText.FilmId }, filmText);
		}

		// DELETE: api/FilmText/5
		[ODataRoute("({id})")]
		public async Task<ActionResult<FilmText>> DeleteFilmText(short id)
		{
			var filmText = await _context.FilmText.FindAsync(id);
			if (filmText == null)
			{
				return NotFound();
			}

			_context.FilmText.Remove(filmText);
			await _context.SaveChangesAsync();

			return filmText;
		}

		private bool FilmTextExists(short id)
		{
			return _context.FilmText.Any(e => e.FilmId == id);
		}
	}
}
