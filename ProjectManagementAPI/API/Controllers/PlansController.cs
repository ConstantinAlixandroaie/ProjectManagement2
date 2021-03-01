using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.API.Repositories;
using ProjectManagementAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlansController:ControllerBase
    {
        private readonly IRepository<Plan> _planRepo;
        public PlansController(IRepository<Plan> planRepo)
        {
            _planRepo = planRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rv = await _planRepo.Get(asNoTracking: true);
            return Ok(rv);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rv = await _planRepo.GetById(id, asNoTracking: true);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Plan plan)
        {
            var rv = await _planRepo.Add(plan);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Plan newData)
        {
            var rv = await _planRepo.Update(id, newData);
            return Ok(rv);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            var rv = await _planRepo.RemoveById(id);
            return Ok(rv);
        }
    }
}
