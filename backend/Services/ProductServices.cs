using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;
using System.Threading.Tasks;

namespace MarketPlace.Services
{
    public class ProductService : IProductServices
    {
        private IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IList<Product>> GetProducts()
        {
            Task<IList<Product>> myList = _repo.GetAll();

            return myList;
        }
        public Task<IList<Product>> GetProductByName(string name)
        {
            Task<IList<Product>> mylist = _repo.GetProductName(name);

            return mylist;
        }

        public Task<Product> GetProductByItemID(int id)
        {
            Task<Product> product = _repo.GetProductByItemID(id);
            return product;
        }
        public void CreateProduct(Product p)
        {
            _repo.InsertProduct(p);
        }
        public void UpdateProduct(int ItemID, Product p)
        {
            _repo.UpdateProduct(ItemID, p);
        }
        public void DeleteProduct(int ItemID)
        {
            _repo.DeleteProduct(ItemID);
        }

    }

}