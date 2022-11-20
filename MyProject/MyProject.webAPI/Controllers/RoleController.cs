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
       // private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public List<RoleDTO> Get()
        {
            return _roleService.GetAll();
        }
        [HttpGet("{id}")]
        public RoleDTO Get(int id)
        {
            return _roleService.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.Delete(id);
        }
        [HttpPut]
        public RoleDTO Update([FromBody]RoleModel model)
        {
            return _roleService.Update(new RoleDTO() { Id = model.Id, Name =model.Name, Description = model.Description });
        }
        [HttpPost]
        public RoleDTO Post([FromBody] RoleModel model)
        {
           RoleDTO r= _roleService.Add(model.Id,model.Name,model.Description);
            return r;
        }
    }
}
