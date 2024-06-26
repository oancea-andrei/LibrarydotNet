using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Core.Mapping;
using LibraryManagement.Database.Repositories;

namespace LibraryManagement.Core.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<RoleResponseDto> GetAll()
        {
            var roles = _roleRepository.GetAll();
            var rolesDtos = roles.MapToRoleResponseDtos();
            return rolesDtos;
        }

        public RoleResponseDto Get(int id)
        {
            try
            {
                var role = _roleRepository.Get(id);
                var roleDto = role.MapToRoleResponseDto();
                return roleDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Create(RoleRequestDto roleDto)
        {
            try
            {
                var role = roleDto.MapToRole();
                _roleRepository.Create(role);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(int id, RoleRequestDto updatedRoleDto)
        {
            try
            {
                var updatedRole = updatedRoleDto.MapToRole();
                _roleRepository.Update(id, updatedRole);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _roleRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
