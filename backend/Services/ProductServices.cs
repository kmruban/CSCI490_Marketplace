using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

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
            //sort list 
            return myList;

        }

        public Product GetProductByName(string name)
        {
            return _repo.GetProductByName(name);
            //format what the movie looks like 
        }

        public Product GetProductByItemID(string id)
        {
            IEnumerable<Product> mylist = _repo.GetAll();
            foreach (Product m in mylist)
            {
                if (m.ItemID == id)
                    return m;
            }
            return null;
        }
        public void CreateProduct(Product m)
        {
            _repo.InsertProduct(m);

        }
        public void UpdateProduct(string name, Product m)
        {
            _repo.UpdateProduct(name, m);
        }
        public void DeleteProduct(string name)
        {
            _repo.DeleteProduct(name);
        }



    }



}