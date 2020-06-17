using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectManagementAPI.Controllers;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IRepository<Client> _clientsRepo;
        public ClientsController(IRepository<Client> clientsRepo)
        {
            _clientsRepo = clientsRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rv = await _clientsRepo.Get(asNoTracking: true);
            return Ok(rv);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rv = await _clientsRepo.GetById(id, true);
            return Ok(rv);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            var rv = await _clientsRepo.RemoveById(id);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult>Add(Client client)
        {
            var rv = await _clientsRepo.Add(client);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Client client)
        {
            var rv = await _clientsRepo.Update(id, client);
            return Ok(rv);
        }

    }
}
