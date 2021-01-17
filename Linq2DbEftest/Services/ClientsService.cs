
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linq2DbEftest.Context;
using Linq2DbEftest.Interfaces;
using Linq2DbEftest.Models;
using LinqToDB;
using LinqToDB.EntityFrameworkCore;

namespace KlantPortaalApi.Services
{
	public class ClientsService : IClientsService
	{
		private readonly SqlLiteContext _dbContext;

		public ClientsService(SqlLiteContext dbContext)
		{
			_dbContext = dbContext;

		}
		public async Task<IEnumerable<Client>> GetAllClients()
		{
			try
			{
				var items = from cl in _dbContext.Clients
							select cl;

				items = items.ToLinqToDB();
				var result = await items.ToListAsync().ConfigureAwait(true);

				return result;
			}
			catch
			{
				throw;
			}
		}

		
		public async Task<IEnumerable<ClientOrders>> GetOrdersForClient(int clientId)
		{
			try
			{
				var query = from cl in _dbContext.Clients
							from or in _dbContext.Orders.LeftJoin(o => o.ClientId == cl.ClientId)
							where cl.ClientId == clientId
							select new ClientOrders
							{
								ClientId = cl.ClientId,
								ClientName = cl.Name,
								OrderId = or == null ? 0 : or.OrderId,
								Description = or == null ? "" : or.Description,
								OrderDate = or == null ? "" : or.OrderDate,
								Country = cl.Country,
								Price = or == null ? 0 : or.Price
							};

				query = query.ToLinqToDB();
				var result = await query.ToListAsync().ConfigureAwait(true);

				//var items = (
				//	from cl in _dbContext.Clients
				//	join or in _dbContext.Orders on cl.ClientId equals or.ClientId into ordersJoin from or in ordersJoin.DefaultIfEmpty()
				//	where cl.ClientId == clientId
				//	select new ClientOrders
				//	{
				//		 ClientId = cl.ClientId,
				//		 ClientName = cl.Name,
				//		 OrderId = or== null?0:or.OrderId,
				//		 Description = or == null ? "": or.Description,
				//		 OrderDate = or == null ? "" : or.OrderDate,
				//		 Country = cl.Country,
				//		 Price = or == null ? 0 : or.Price
				//    }
				//	)
				//	.AsNoTracking()
				//	.ToList();

				return result;
			}
			catch
			{
				throw;
			}

		}
		public async Task<Client> GetClientById(int clientId)
		{
			try
			{
				var item = _dbContext.Clients
					.Where(_ => _.ClientId == clientId);

				item = item.ToLinqToDB();
				var result = await item.FirstOrDefaultAsync().ConfigureAwait(true);
				return result;
			}
			catch
			{
				throw;
			}

		}


	}
}
