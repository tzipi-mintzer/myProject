using AutoMapper;
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
    public class PermissionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService,IMapper mapper)
        {

            _permissionService = permissionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<PermissionDTO>> Get()
        {
            return await _permissionService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<PermissionDTO> Get(int id)
        {
            return await _permissionService.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<PermissionDTO> Update([FromBody] PermissionModel model)
        {
            return await _permissionService.UpdateAsync(new PermissionDTO() { Id = model.Id, Name = model.Name, Description = model.Description });
        }
        [HttpPost]
        public async Task<PermissionDTO> Post([FromBody] PermissionModel model)
        {
           PermissionDTO p = await _permissionService.AddAsync(model.Id, model.Name, model.Description);
            return p;
        }
    }
}

