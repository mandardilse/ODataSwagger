using System.Linq;
using Models.Db;
using Models.Db.Entities;

namespace Services
{
	public class StoreService
	{
		private readonly sakilaContext _context;

		public StoreService(sakilaContext context)
		{
			_context = context;
		}

		public IQueryable<Customer> GetCustomers(int key)
		{
			return _context.Customer.Where(c => c.StoreId == key);
		}
	}
}