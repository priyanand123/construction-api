using AutoMapper;
using ConstructionBilling.Application.Dtos;
using ConstructionBilling.Application.Interfaces;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on roles.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="roleService"/> class.
        /// </summary>
        /// <param name="roleRepository">The repository for accessing roleDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<RoleDto>> GetRolesDetails(int? id)
        {
            var roles = await _roleRepository.GetRolesDetails(id);

            var roleDetails = _mapper.Map<IEnumerable<RoleDto>>(roles);
            return roleDetails;
        }
        /// <inheritdoc/>
        public async Task<RoleDto> InsertRoleDetails(RoleDto roleDto)
        {
            
                var role = _mapper.Map<Roles>(roleDto);
                var insertedData = await _roleRepository.InsertRoleDetails(role);
                if (insertedData == null)
                {
                    // Handle the case where the insertion was not successful
                    throw new Exception("Role insertion failed.");
                }
            return _mapper.Map<RoleDto>(insertedData);
            
        }
        /// <inheritdoc/>
        public async Task UpdateRoleDetails(RoleDto roleDto)
        {
            var role = _mapper.Map<Roles>(roleDto);
            await _roleRepository.UpdateRoleDetails(role);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteRoleDetails(int id)
        {
            return await _roleRepository.DeleteRoleDetails(id);
        }
    }
}
