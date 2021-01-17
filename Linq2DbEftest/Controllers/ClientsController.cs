using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Web;
using Linq2DbEftest.Interfaces;

namespace Linq2DbEftest.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ClientsController: ControllerBase
	{
		private readonly IClientsService _clientsService;
		public ClientsController(IClientsService clientsService)
		{
			_clientsService = clientsService;
		}
		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
		try
			{
				var items = await _clientsService.GetAllClients().ConfigureAwait(false);
				return Ok(items);
			}
				catch (Exception ex)
				{
					return BadRequest(new { message = ex.Message });
				}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			try
			{
				var item = await _clientsService.GetClientById(id).ConfigureAwait(false);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet("Orders/{clientId}")]
		public async Task<ActionResult> GetOrdersForClient(int clientId)
		{
			try
			{
				var item = await _clientsService.GetOrdersForClient(clientId).ConfigureAwait(false);
				if (item == null)
				{
					return NotFound();
				}
				return Ok(item);
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}
	}
}
