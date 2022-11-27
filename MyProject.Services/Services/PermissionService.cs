using AutoMapper;
using MyProject.Common;
using MyProject.Repositories.Entities;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
  public class PermissionService:IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionService(IPermissionRepository permissionRepository,IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }
        public async Task<PermissionDTO> AddAsync(int id, string name, string description)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.AddAsync(id, name, description));
        }

        public async Task DeleteAsync(int id)
        {
           await _permissionRepository.DeleteAsync(id);
        }

        public async Task<List<PermissionDTO>> GetAllAsync()
        {
            return _mapper.Map<List<PermissionDTO>>(await _permissionRepository.GetAllAsync());
        }

        public async Task<PermissionDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.GetByIdAsync(id));
        }

        public async Task<PermissionDTO> UpdateAsync(PermissionDTO Permission)
        {
            return _mapper.Map<PermissionDTO>(await _permissionRepository.UpdateAsync( _mapper.Map<Permission>(Permission)));

        }
    }
}
