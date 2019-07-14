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
// 	public class StoreController : ODataController
// 	{
// 		private readonly sakilaContext _context;

// 		public StoreController(sakilaContext context)
// 		{
// 			_context = context;
// 		}

// 		// GET: api/Store
// 		[ODataRoute]
// 		public async Task<ActionResult<IEnumerable<Store>>> GetStore()
// 		{
// 			return await _context.Store.ToListAsync();
// 		}

// 		// GET: api/Store/5
// 		[ODataRoute("{id}")]
// 		public async Task<ActionResult<Store>> GetStore(byte id)
// 		{
// 			var store = await _context.Store.FindAsync(id);

// 			if (store == null)
// 			{
// 				return NotFound();
// 			}

// 			return store;
// 		}

// 		// PUT: api/Store/5
// 		[HttpPut("{id}")]
// 		public async Task<IActionResult> PutStore(byte id, Store store)
// 		{
// 			if (id != store.StoreId)
// 			{
// 				return BadRequest();
// 			}

// 			_context.Entry(store).State = EntityState.Modified;

// 			try
// 			{
// 				await _context.SaveChangesAsync();
// 			}
// 			catch (DbUpdateConcurrencyException)
// 			{
// 				if (!StoreExists(id))
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

// 		// POST: api/Store
// 		[HttpPost]
// 		public async Task<ActionResult<Store>> PostStore(Store store)
// 		{
// 			_context.Store.Add(store);
// 			await _context.SaveChangesAsync();

// 			return CreatedAtAction("GetStore", new { id = store.StoreId }, store);
// 		}

// 		// DELETE: api/Store/5
// 		[HttpDelete("{id}")]
// 		public async Task<ActionResult<Store>> DeleteStore(byte id)
// 		{
// 			var store = await _context.Store.FindAsync(id);
// 			if (store == null)
// 			{
// 				return NotFound();
// 			}

// 			_context.Store.Remove(store);
// 			await _context.SaveChangesAsync();

// 			return store;
// 		}

// 		private bool StoreExists(byte id)
// 		{
// 			return _context.Store.Any(e => e.StoreId == id);
// 		}
// 	}
// }
