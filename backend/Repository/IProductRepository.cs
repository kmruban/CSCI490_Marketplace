using System.Collections.Generic;
using MarketPlace.Models;
using System.Threading.Tasks;

namespace MarketPlace.Repository
{
    public interface IProductRepository
    {
        public Task<IList<Product>> GetAll();
        public Task<IList<Product>> GetProductName(string name);
        public Task<Product> GetProductByItemID(int ItemID);
        public void InsertProduct(Product p);
        public void UpdateProduct(int ItemID, Product p);
        public void DeleteProduct(int ItemID);
    }

}