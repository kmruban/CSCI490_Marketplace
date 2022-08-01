using System.Collections.Generic;
using MarketPlace.Models;
using System.Threading.Tasks;

namespace MarketPlace.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetPName(string name);
        public Product GetProductByItemID(int ItemID);
        public void InsertProduct(Product p);
        public void UpdateProduct(int ItemID, Product p);
        public void DeleteProduct(int ItemID);
    }

}