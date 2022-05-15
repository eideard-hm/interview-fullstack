using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;

namespace Inventory.Application.Services
{
    public class ProductService : IBaseService<Product, int>
    {
        private readonly IBaseRepository<Product, int> _productRepository;
        public ProductService(IBaseRepository<Product, int> repository)
        {
            _productRepository = repository;
        }
        public Product Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("El 'Producto' es requerido!");
            }
            var insertProd = _productRepository.Add(product);
            _productRepository.SaveAllChanges();
            return insertProd;
        }

        public void Delete(int productId)
        {
            _productRepository.Delete(productId);
            _productRepository.SaveAllChanges();
        }

        public void Edit(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("El 'Producto' a modificar el requerido!");
            }
            _productRepository.Edit(product);
            _productRepository.SaveAllChanges();
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
