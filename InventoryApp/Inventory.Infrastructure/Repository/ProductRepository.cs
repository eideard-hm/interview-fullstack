using Inventory.Domain.Entities;
using Inventory.Domain.Interfaces.Repository;
using Inventory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repository
{
    public class ProductRepository : IBaseRepository<Product, int>
    {
        private readonly InvoiceContext _db;
        public ProductRepository(InvoiceContext db)
        {
            _db = db;
        }
        public Product Add(Product product)
        {
            _db.Products.Add(product);
            return product;
        }

        public void Delete(int productId)
        {
            var deleteProd = _db.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if (deleteProd != null)
            {
                _db.Products.Remove(deleteProd);
            }
        }

        public void Edit(Product product)
        {
            var updateProd = _db.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if(updateProd != null)
            {
                updateProd.Name = product.Name;
                updateProd.Description = product.Description;
                updateProd.Cost = product.Cost;
                updateProd.Price = product.Price;
                updateProd.Stock = product.Stock;

                _db.Entry(updateProd).State = EntityState.Modified;
            }
        }

        public List<Product> GetAll()
        {
            return _db.Products.AsNoTracking().ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
        }

        public void SaveAllChanges()
        {
            _db.SaveChanges();
        }
    }
}
