using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetProductByName(string name);
        public void InsertProduct(Product p);
        public void UpdateProduct(string name, Product p);
        public void DeleteProduct(int id);
    }
    
}