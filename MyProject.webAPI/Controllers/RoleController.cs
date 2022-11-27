using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common;
using MyProject.Mock;
using MyProject.Services.Interfaces;
using MyProject.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyProject.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {

            _roleService = roleService;
        }
        [HttpGet]
        public async Task<List<RoleDTO>> Get()
        {
            return await _roleService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<RoleDTO> Get(int id)
        {
            return await _roleService.GetByIdAsync(id);
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _roleService.DeleteAsync(id);
        }
        [HttpPut]
        public async Task<RoleDTO> Update([FromBody]RoleModel model)
        {
            return await _roleService.UpdateAsync(new RoleDTO() { Id = model.Id, Name =model.Name, Description = model.Description });
        }
        [HttpPost]
        public async Task<RoleDTO> Post([FromBody] RoleModel model)
        {
           RoleDTO r= await _roleService.AddAsync(model.Id,model.Name,model.Description);
            return r;
        }
    }
}
