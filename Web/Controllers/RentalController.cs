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
// 	public class RentalController : ODataController
// 	{
// 		private readonly sakilaContext _context;

// 		public RentalController(sakilaContext context)
// 		{
// 			_context = context;
// 		}

// 		// GET: api/Rental
// 		[ODataRoute]
// 		public async Task<ActionResult<IEnumerable<Rental>>> GetRental()
// 		{
// 			return await _context.Rental.ToListAsync();
// 		}

// 		// GET: api/Rental/5
// 		[ODataRoute("{id}")]
// 		public async Task<ActionResult<Rental>> GetRental(int id)
// 		{
// 			var rental = await _context.Rental.FindAsync(id);

// 			if (rental == null)
// 			{
// 				return NotFound();
// 			}

// 			return rental;
// 		}

// 		// PUT: api/Rental/5
// 		[HttpPut("{id}")]
// 		public async Task<IActionResult> PutRental(int id, Rental rental)
// 		{
// 			if (id != rental.RentalId)
// 			{
// 				return BadRequest();
// 			}

// 			_context.Entry(rental).State = EntityState.Modified;

// 			try
// 			{
// 				await _context.SaveChangesAsync();
// 			}
// 			catch (DbUpdateConcurrencyException)
// 			{
// 				if (!RentalExists(id))
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

// 		// POST: api/Rental
// 		[HttpPost]
// 		public async Task<ActionResult<Rental>> PostRental(Rental rental)
// 		{
// 			_context.Rental.Add(rental);
// 			await _context.SaveChangesAsync();

// 			return CreatedAtAction("GetRental", new { id = rental.RentalId }, rental);
// 		}

// 		// DELETE: api/Rental/5
// 		[HttpDelete("{id}")]
// 		public async Task<ActionResult<Rental>> DeleteRental(int id)
// 		{
// 			var rental = await _context.Rental.FindAsync(id);
// 			if (rental == null)
// 			{
// 				return NotFound();
// 			}

// 			_context.Rental.Remove(rental);
// 			await _context.SaveChangesAsync();

// 			return rental;
// 		}

// 		private bool RentalExists(int id)
// 		{
// 			return _context.Rental.Any(e => e.RentalId == id);
// 		}
// 	}
// }
