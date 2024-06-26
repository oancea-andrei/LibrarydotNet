using LibraryManagement.Database.Context;
using LibraryManagement.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Database.Repositories
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(LibraryDbContext context) : base(context)
        {
        }

        public List<Role> GetAll()
        {
            return _libraryDbContext.Roles.ToList();
        }

        public Role Get(int id)
        {
            var role = _libraryDbContext.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role;
        }

        public void Create(Role role)
        {
            if(_libraryDbContext.Roles.Any(r => r.Name == role.Name))
            {
                throw new Exception($"Role with name {role.Name} already exists");
            }
            _libraryDbContext.Roles.Add(role);
            SaveChanges();
        }

        public void Update(int id, Role updatedRole)
        {
            var role = _libraryDbContext.Roles.Find(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if(_libraryDbContext.Roles.Any(r => r.Name == updatedRole.Name && r.Name != role.Name))
            {
                throw new Exception($"Role with name {updatedRole.Name} already exists");
            }

            role.Name = updatedRole.Name;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _libraryDbContext.Roles
                                        .Where(r => r.Id == id)
                                        .Include(r => r.Users)
                                        .FirstOrDefault();
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if(role.Users.Count > 0)
            {
                throw new Exception("Role has users assigned to it and can't be deleted");
            }

            _libraryDbContext.Roles.Remove(role);
            SaveChanges();
        }
    }
}
