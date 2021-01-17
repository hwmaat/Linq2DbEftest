

using Linq2DbEftest.Models;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Linq2DbEftest.Interfaces
{
	public interface IClientsService
	{
		Task<IEnumerable<Client>> GetAllClients();
		Task<IEnumerable<Order>> GetOrdersForClient(int clientId);
		Task<Client> GetClientById(int clientId);

	}
}
