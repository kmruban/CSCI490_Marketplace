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

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> myList = _repo.GetAll();

            return myList;
        }
        public IEnumerable<Product> GetProductByName(string name)
        {
            IEnumerable<Product> mylist = _repo.GetPName(name);

            return mylist;
        }

        public Product GetProductByItemID(int id)
        {
            Product product = _repo.GetProductByItemID(id);
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