using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class UserService : IBaseService<User, int>
    {
        private readonly IBaseRepository<User, int> _repository;
        public UserService(IBaseRepository<User, int> repository)
        {
            _repository = repository;
        }

        public User Add(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("El 'Uusario' es requerido!");
            }
            var insertUser = _repository.Add(user);
            _repository.SaveAllChanges();
            return insertUser;
        }

        public void Delete(int userId)
        {
            _repository.Delete(userId);
            _repository.SaveAllChanges();
        }

        public void Edit(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("El 'Usuario' es requerido!");
            }
            _repository.Edit(user);
            _repository.SaveAllChanges();
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
