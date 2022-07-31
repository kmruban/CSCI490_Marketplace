
using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services
{
    public interface IProductServices
    {
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductByName(string name);
        public Product GetProductByItemID(int id);
        public void CreateProduct(Product p);
        public void UpdateProduct(int ItemID, Product p);
        public void DeleteProduct(int id);

    }

}
