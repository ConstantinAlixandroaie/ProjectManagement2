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
    public class ProjectsController:ControllerBase
    {
        private readonly IRepository<Project> _projectRepository;
        public ProjectsController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rv = await _projectRepository.Get();
            return Ok(rv);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBytId(int id)
        {
            var rv = await _projectRepository.GetById(id);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id,Project newData)
        {
            var rv = await _projectRepository.Update(id, newData);
            return Ok(rv);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovebyId(int id)
        {
            var rv = await _projectRepository.RemoveById(id);
            return Ok(rv);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Project project)
        {
            var rv = await _projectRepository.Add(project);
            return Ok(rv);
        }
    }
}
