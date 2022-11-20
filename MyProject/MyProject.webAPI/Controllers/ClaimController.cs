using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Mock;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
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
        private readonly IClaimRepository _claimRepository;
   

        public ClaimController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        [HttpGet]
        public List<Claim> Get()
        {
            return _claimRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Claim Get(int id)
        {
            return _claimRepository.GetById(id);
        }
    }
}
