using System.Collections.Generic;
using MarketPlace.Models;
using MySql.Data.MySqlClient;
using System;

namespace MarketPlace.Repository
{

    public class ProductRepository : IProductRepository
    {
        private MySqlConnection _connection;
        public ProductRepository()
        {
            string connectionString = "server=localhost;userid=root;password=kyleruban;database=mydb";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();


        }
        ~ProductRepository()
        {
            _connection.Close();
        }

        public IEnumerable<Product> GetAll()

        {
            var statement = "Select * from Product";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();

            List<Product> newList = new List<Product>(1000);
            while (results.Read())
            {
                Product m = new Product
                {
                    Name = (string)results[0],
                    ItemID = (string)results[1],
                    Quantity = (string)results[2],
                    Price = (string)results[3]
                };
                newList.Add(m);

            }
            results.Close();
            return newList;

            //return movies;
        }

        public Product GetProductByName(string name)

        {
            //need statement and command
            var statement = "Select * from Product where Name = @newName ";
            var command = new MySqlCommand(statement, _connection); //always takes statement and connection
            command.Parameters.AddWithValue("@newName", name);


            var results = command.ExecuteReader();
            Product m = null;
            if (results.Read())
            {
                m = new Product
                {
                    Name = (string)results[1],
                    ItemID = (string)results[3],
                    Quantity = (string)results[2],
                    Price = (string)results[4]
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

            Console.WriteLine(result);

        }

        public void UpdateProduct(string name, Product productIn)
        {
            var statement = "Update Product  Set Name=@newName, ItemID=@newItemID, Quantity=@newQuantity, Price=@newPrice Where Name=@updateName";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newName", productIn.Name);
            command.Parameters.AddWithValue("@newItemID", productIn.ItemID);
            command.Parameters.AddWithValue("@newQuantity", productIn.Quantity);
            command.Parameters.AddWithValue("@newPrice", productIn.Price);
            command.Parameters.AddWithValue("@updateName", name);

            int result = command.ExecuteNonQuery();
        }

        public void DeleteProduct(string name)

        {
            var statement = "DELETE FROM Product  Where Name=@deleteName";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteName", name);

            int result = command.ExecuteNonQuery();

        }

    }


}
