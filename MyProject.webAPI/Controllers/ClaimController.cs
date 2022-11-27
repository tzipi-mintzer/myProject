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
    public class ClaimController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public ClaimController(IClaimService claimService, IMapper mapper)
        {

            _claimService = claimService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<ClaimDTO>> Get()
        {
            return await _claimService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<ClaimDTO> Get(int id)
        {
            return await _claimService.GetByIdAsync(id);
        }
        [HttpPut]
        public async Task<ClaimDTO> Update([FromBody] ClaimModel model)
        {
            return await _claimService.UpdateAsync(new ClaimDTO() { Id = model.Id,RoleId=model.RoleId,PermissionId=model.PermissionId,Policy= (Common.EPolicyDTO)model.Policy});
        }
        [HttpPost]
        public async Task<ClaimDTO> Post([FromBody] ClaimModel model)
        {
            ClaimDTO p = await _claimService.AddAsync(model.Id, model.RoleId,  model.PermissionId, (Common.EPolicyDTO)model.Policy);
            return p;
        }
    }
}
