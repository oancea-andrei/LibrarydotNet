using LibraryManagement.Database.Context;
using LibraryManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(LibraryDbContext libraryDbContext) : base(libraryDbContext)
        {
        }

        public void Register(User user)
        {
            if(_libraryDbContext.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("Email already exists");
            }

            _libraryDbContext.Users.Add(user);
            SaveChanges();
        }

        public User GetByEmail(string email)
        {
            var user = _libraryDbContext.Users
                                        .Where(u => u.Email == email)
                                        .Include(u => u.Role)
                                        .FirstOrDefault();
            if(user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public List<User> GetAll()
        {
            return _libraryDbContext.Users
                                    .Include(u => u.Role)
                                    .ToList();
        }

        public User Get(int id)
        {
            var user = _libraryDbContext.Users
                                        .Where(u => u.Id == id)
                                        .Include(u => u.Role)
                                        .FirstOrDefault();
            if(user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void Update(int id, User updatedUser)
        {
            var user = _libraryDbContext.Users.Find(id);
            if(user == null)
            {
                throw new Exception("User not found");
            }

            var role = _libraryDbContext.Roles.Find(updatedUser.RoleId);
            if(role == null)
            {
                throw new Exception("Role not found");
            }

            if(_libraryDbContext.Users.Any(u => u.Email == updatedUser.Email && u.Email != user.Email))
            {
                throw new Exception("Email already exists");
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            user.RoleId = updatedUser.RoleId;

            SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _libraryDbContext.Users.Find(id);
            if(user == null)
            {
                throw new Exception("User not found");
            }

            _libraryDbContext.Users.Remove(user);
            SaveChanges();
        }
    }
}
