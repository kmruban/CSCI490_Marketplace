
using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services
{
    public interface IProductServices {


    public IEnumerable<Product> GetProducts();

    public Product GetProductByName(string name);

    public Product GetProductByItemID(string id);
    public void CreateProduct(Product p);
    public void UpdateProduct(string name, Product p);
    public void DeleteProduct(string name);




    }





}
