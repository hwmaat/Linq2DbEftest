
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Linq2DbEftest.Context;
using Linq2DbEftest.Interfaces;
using Linq2DbEftest.Models;


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
				var items =  await _dbContext.Clients
					.AsNoTracking()
					.ToListAsync()
					.ConfigureAwait(false);
				;
				return items;
			}
			catch
			{
				throw;
			}
		}

		
		public async Task<IEnumerable<Order>> GetOrdersForClient(int clientId)
		{
			try
			{
				var items = await _dbContext.Orders
					.Where(_ => _.ClientId == clientId)
					.AsNoTracking()
					.ToListAsync();

				return items;
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
				var item = await _dbContext.Clients
					.Where(_ => _.ClientId == clientId)
					.AsNoTracking()
					.FirstOrDefaultAsync();

				return item;
			}
			catch
			{
				throw;
			}

		}


	}
}
