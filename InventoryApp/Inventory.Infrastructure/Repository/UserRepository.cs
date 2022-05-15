using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class UserRepository : IBaseRepository<User, int>
    {
        private readonly InvoiceContext _db;
        public UserRepository(InvoiceContext db)
        {
            _db = db;
        }
        public User Add(User user)
        {
            _db.Users.Add(user);
            return user;
        }

        public void Delete(int userId)
        {
            var deleteUser  = _db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (deleteUser != null)
            {
                _db.Users.Remove(deleteUser);
            }
        }

        public void Edit(User user)
        {
            var updateUser = _db.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            if(updateUser != null)
            {
                updateUser.FullName = user.FullName;
                updateUser.DocumentType = user.DocumentType;
                updateUser.DocumentNumber = user.DocumentNumber;
                updateUser.Age = user.Age;

                _db.Entry(updateUser).State = EntityState.Modified;
            }
        }

        public List<User> GetAll()
        {
            return _db.Users.AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return _db.Users.AsNoTracking().FirstOrDefault(u => u.UserId == id);
        }

        public void SaveAllChanges()
        {
            _db.SaveChanges();
        }
    }
}
