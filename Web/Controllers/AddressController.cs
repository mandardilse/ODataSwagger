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
// 	[ApiVersion("1.0")]
// 	[ODataRoutePrefix("api/[controller]")]
// 	public class AddressController : ODataController
// 	{
// 		private readonly sakilaContext _context;

// 		public AddressController(sakilaContext context)
// 		{
// 			_context = context;
// 		}

// 		// GET: api/Address
// 		[ODataRoute]
// 		public async Task<ActionResult<IEnumerable<Address>>> GetAddress() => await _context.Address.ToListAsync();

// 		// GET: api/Address/5
// 		[ODataRoute("{id}")]
// 		public async Task<ActionResult<Address>> GetAddress(short id)
// 		{
// 			var address = await _context.Address.FindAsync(id);

// 			if (address == null)
// 			{
// 				return NotFound();
// 			}

// 			return address;
// 		}

// 		// PUT: api/Address/5
// 		[HttpPut("{id}")]
// 		public async Task<IActionResult> PutAddress(short id, Address address)
// 		{
// 			if (id != address.AddressId)
// 			{
// 				return BadRequest();
// 			}

// 			_context.Entry(address).State = EntityState.Modified;

// 			try
// 			{
// 				await _context.SaveChangesAsync();
// 			}
// 			catch (DbUpdateConcurrencyException)
// 			{
// 				if (!AddressExists(id))
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

// 		// POST: api/Address
// 		[HttpPost]
// 		public async Task<ActionResult<Address>> PostAddress(Address address)
// 		{
// 			_context.Address.Add(address);
// 			await _context.SaveChangesAsync();

// 			return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
// 		}

// 		// DELETE: api/Address/5
// 		[HttpDelete("{id}")]
// 		public async Task<ActionResult<Address>> DeleteAddress(short id)
// 		{
// 			var address = await _context.Address.FindAsync(id);
// 			if (address == null)
// 			{
// 				return NotFound();
// 			}

// 			_context.Address.Remove(address);
// 			await _context.SaveChangesAsync();

// 			return address;
// 		}

// 		private bool AddressExists(short id)
// 		{
// 			return _context.Address.Any(e => e.AddressId == id);
// 		}
// 	}
// }
