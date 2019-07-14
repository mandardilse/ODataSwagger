// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNet.OData;
// using Microsoft.AspNet.OData.Routing;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Models.Db;
// using Models.Db.Entities;

// namespace Web.Controllers
// {
// 	[ODataRoutePrefix("api/[controller]")]
// 	[ApiVersion("1.0")]
// 	public class LanguageController : ODataController
// 	{
// 		private readonly sakilaContext _context;

// 		public LanguageController(sakilaContext context)
// 		{
// 			_context = context;
// 		}

// 		// GET: api/Language
// 		[ODataRoute]
// 		public async Task<ActionResult<IEnumerable<Language>>> GetLanguage()
// 		{
// 			return await _context.Language.ToListAsync();
// 		}

// 		// GET: api/Language/5
// 		[ODataRoute("{id}")]
// 		public async Task<ActionResult<Language>> GetLanguage(byte id)
// 		{
// 			var language = await _context.Language.FindAsync(id);

// 			if (language == null)
// 			{
// 				return NotFound();
// 			}

// 			return language;
// 		}

// 		// PUT: api/Language/5
// 		[HttpPut("{id}")]
// 		public async Task<IActionResult> PutLanguage(byte id, Language language)
// 		{
// 			if (id != language.LanguageId)
// 			{
// 				return BadRequest();
// 			}

// 			_context.Entry(language).State = EntityState.Modified;

// 			try
// 			{
// 				await _context.SaveChangesAsync();
// 			}
// 			catch (DbUpdateConcurrencyException)
// 			{
// 				if (!LanguageExists(id))
// 				{
// 					return NotFound();
// 				}
// 				else
// 				{
// 					throw;
// 				}
// 			}

// 			return NoContent();
// 		}

// 		// POST: api/Language
// 		[HttpPost]
// 		public async Task<ActionResult<Language>> PostLanguage(Language language)
// 		{
// 			_context.Language.Add(language);
// 			await _context.SaveChangesAsync();

// 			return CreatedAtAction("GetLanguage", new { id = language.LanguageId }, language);
// 		}

// 		// DELETE: api/Language/5
// 		[HttpDelete("{id}")]
// 		public async Task<ActionResult<Language>> DeleteLanguage(byte id)
// 		{
// 			var language = await _context.Language.FindAsync(id);
// 			if (language == null)
// 			{
// 				return NotFound();
// 			}

// 			_context.Language.Remove(language);
// 			await _context.SaveChangesAsync();

// 			return language;
// 		}

// 		private bool LanguageExists(byte id)
// 		{
// 			return _context.Language.Any(e => e.LanguageId == id);
// 		}
// 	}
// }
