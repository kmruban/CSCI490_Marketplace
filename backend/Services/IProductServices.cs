
using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;
using System.Threading.Tasks;

namespace MarketPlace.Services
{
    public interface IProductServices
    {
        public Task<IList<Product>> GetProducts();
        public Task<IList<Product>> GetProductByName(string name);
        public Task<Product> GetProductByItemID(int id);
        public void CreateProduct(Product p);
        public void UpdateProduct(int ItemID, Product p);
        public void DeleteProduct(int ItemID);

    }

}
