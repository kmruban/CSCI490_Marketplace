using System.Collections.Generic;
using MarketPlace.Models;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MySqlConnection _connection;
        //private readonly MarketplaceContext _context;
        public ProductRepository()
        {
            //_context = context;
            string connectionString = "server=localhost;userid=root;password=kyleruban;database=mydb";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }
        ~ProductRepository()
        {
            _connection.Close();
        }

        public async Task<IList<Product>> GetAll()
        {
            var statement = "Select * from Product";
            var command = new MySqlCommand(statement, _connection);
            var results = await command.ExecuteReaderAsync();
            IList<Product> newList = new List<Product>();
            while (results.Read())
            {
                Product m = new Product
                {
                    Name = (string)results[0],
                    ItemID = (int)results[1],
                    Quantity = (int)results[2],
                    Price = (double)results[3]
                };
                newList.Add(m);

            }
            results.Close();
            return newList;
        }

        public async Task<IList<Product>> GetProductName(string name)
        {
            var statement = "Select * from Product WHERE Name = @enteredName";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@enteredName", name);
            var results = await command.ExecuteReaderAsync();
            IList<Product> list = new List<Product>();
            if (results.Read())
            {
                Product product = new Product
                {
                    Name = (string)results[0],
                    ItemID = (int)results[1],
                    Quantity = (int)results[2],
                    Price = (double)results[3]
                };
                list.Add(product);
            }
            results.Close();
            return list;
        }

        public async Task<Product> GetProductByItemID(int ItemID)
        {
            var statement = "Select * from Product WHERE ItemID = @id";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@id", ItemID);
            var results = await command.ExecuteReaderAsync();
            Product m = null;
            if (results.Read())
            {
                m = new Product
                {
                    Name = (string)results[0],
                    ItemID = (int)results[1],
                    Quantity = (int)results[2],
                    Price = (double)results[3]
                };
            }
            results.Close();
            return m;
        }

        public void InsertProduct(Product m)
        {
            var statement = "Insert into Product (Name, ItemId, Quantity, Price) Values(@n,@i,@q,@p)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@n", m.Name);
            command.Parameters.AddWithValue("@i", m.ItemID);
            command.Parameters.AddWithValue("@q", m.Quantity);
            command.Parameters.AddWithValue("@p", m.Price);

            int result = command.ExecuteNonQuery();
        }
        public void UpdateProduct(int ItemID, Product productIn)
        {
            var statement = "Update Product Set Name=@newName, Quantity=@newQuantity, Price=@newPrice Where ItemID=@updateID";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", productIn.Name);
            command.Parameters.AddWithValue("@newQuantity", productIn.Quantity);
            command.Parameters.AddWithValue("@newPrice", productIn.Price);
            command.Parameters.AddWithValue("@updateID", ItemID);

            int result = command.ExecuteNonQuery();
        }
        public void DeleteProduct(int ItemID)
        {
            var statement = "DELETE FROM Product Where ItemID=@deleteID";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteID", ItemID);

            int result = command.ExecuteNonQuery();

        }

    }


}
