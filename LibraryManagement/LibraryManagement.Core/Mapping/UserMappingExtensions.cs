using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Database.Entities;

namespace LibraryManagement.Core.Mapping
{
    public static class UserMappingExtensions
    {
        public static User MapToUser(this UserRequestDto userRequestDto)
        {
            return new User
            {
                Name = userRequestDto.Name,
                Email = userRequestDto.Email,
                Password = userRequestDto.Password,
                RoleId = userRequestDto.RoleId
            };
        }

        public static UserResponseDto MapToUserResponseDto(this User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.Name
            };
        }

        public static List<UserResponseDto> MapToUserResponseDtos(this List<User> users)
        {
            return users.Select(user => user.MapToUserResponseDto()).ToList();
        }
    }
}
