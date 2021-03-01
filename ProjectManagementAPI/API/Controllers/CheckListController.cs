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
    public class CheckListController:ControllerBase
    {
        private readonly IRepository<CheckList> _checkListRepo;
        public CheckListController(IRepository<CheckList> checkListRepo)
        {
            _checkListRepo = checkListRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rv = await _checkListRepo.Get(asNoTracking:true);
            return Ok(rv);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rv = await _checkListRepo.GetById(id, asNoTracking: true);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CheckList checkList)
        {
            var rv = await _checkListRepo.Add(checkList);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult>Update(int id,CheckList newData)
        {
            var rv = await _checkListRepo.Update(id, newData);
            return Ok(rv);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>RemoveById(int id)
        {
            var rv = await _checkListRepo.RemoveById(id);
            return Ok(rv);
        }
    }
}
