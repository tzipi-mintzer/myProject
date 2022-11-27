using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {

            _permissionService = permissionService;
        }
        [HttpGet]
        public async Task<List<Permission>> Get()
        {
            return await _permissionService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Permission Get(int id)
        {
            return _permissionService.GetById(id);
        }
        [HttpPut]
        public async Task<Role> Update([FromBody] RoleModel model)
        {
            return await _roleService.UpdateAsync(new Role() { Id = model.Id, Name = model.Name, Description = model.Description });
        }
        [HttpPost]
        public async Task<Role> Post([FromBody] RoleModel model)
        {
            Role r = await _roleService.AddAsync(model.Id, model.Name, model.Description);
            return r;
        }
    }
}

