using LibraryManagement.Core.Dtos.Request;
using LibraryManagement.Core.Dtos.Response;
using LibraryManagement.Core.Mapping;
using LibraryManagement.Database.Repositories;

namespace LibraryManagement.Core.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly AuthenticationService _authenticationService;

        public UserService(UserRepository userRepository, AuthenticationService authenticationService)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
        }

        public void Register(UserRequestDto userRequestDto)
        {
            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);
                userRequestDto.Password = passwordHash;
                var user = userRequestDto.MapToUser();
                _userRepository.Register(user);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string Login(LoginRequestDto loginDto)
        {
            try
            {
                var user = _userRepository.GetByEmail(loginDto.Email);

                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
                {
                    throw new Exception("Invalid password");
                }

                string token = _authenticationService.GenerateToken(user);
                return token;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<UserResponseDto> GetAll()
        {
            var users = _userRepository.GetAll();
            var userResponseDtos = users.MapToUserResponseDtos();
            return userResponseDtos;
        }

        public UserResponseDto Get(int id)
        {
            try
            {
                var user = _userRepository.Get(id);
                var userResponseDto = user.MapToUserResponseDto();
                return userResponseDto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(int id, UserRequestDto updatedUserDto)
        {
            try
            {
                var updatedUserEntity = updatedUserDto.MapToUser();
                _userRepository.Update(id, updatedUserEntity);
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
                _userRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
