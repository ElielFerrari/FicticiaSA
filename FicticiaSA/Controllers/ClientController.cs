using BusinessLogic.Dto;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FicticiaSA.Controllers
{
    [Route("clientes")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost] //Create client
        public async Task<ActionResult> AddClient([FromForm] NewClientDto clientDto)
        {
            try
            {
                await _clientService.AddClient(clientDto);
                return Ok("Creaste un cliente.");
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpGet] //Get all clients
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _clientService.GetAll());
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPut] //Update Client
        public async Task<ActionResult> UpdateClient([FromForm]Client client)
        {
            try
            {
                await _clientService.UpdateClient(client);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpDelete] //Delete client
        public async Task<ActionResult> DeleteClient(int id)
        {
            try
            {
                await _clientService.DeleteClient(id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
