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
    public class ClaimService:IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IMapper _mapper;

        public ClaimService(IClaimRepository claimRepository,IMapper mapper)
        {
            _claimRepository = claimRepository;
            _mapper = mapper;
        }

        public ClaimDTO Add(int id, int roleId, int permissionId, EPolicyDTO ePolicy)
        {
            EPolicy e = (EPolicy)ePolicy;
            return _mapper.Map<ClaimDTO>(_claimRepository.Add(id,roleId, permissionId, e));
        }

        public void Delete(int id)
        {
            _claimRepository.Delete(id);
        }

        public List<ClaimDTO> GetAll()
        {
            return _mapper.Map<List<ClaimDTO>>(_claimRepository.GetAll());
        }

        public ClaimDTO GetById(int id)
        {
            return _mapper.Map<ClaimDTO>(_claimRepository.GetById(id));
        }

        public ClaimDTO Update(ClaimDTO Claim)
        {
            return _mapper.Map<ClaimDTO>(_claimRepository.Update(_mapper.Map<Claim>(Claim)));

        }

    }
}
