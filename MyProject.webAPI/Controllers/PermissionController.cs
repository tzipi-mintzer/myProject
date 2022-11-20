﻿using Microsoft.AspNetCore.Http;
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
    public class PermissionController : ControllerBase
    {
        private readonly IpermissionRepository _permissionRepository;
        public PermissionController()
        {
            var mock = new MockContext();
            _permissionRepository = new PermissonRepository(mock);
        }
        [HttpGet]
        public List<Permission> Get()
        {
            return _permissionRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Permission Get(int id)
        {
            return _permissionRepository.GetById(id);
        }

    }
}
