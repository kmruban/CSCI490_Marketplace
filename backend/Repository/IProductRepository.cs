using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetPName(string name);
        public void InsertProduct(Product p);
        public void UpdateProduct(int ItemID, Product p);
        public void DeleteProduct(int id);
    }

}