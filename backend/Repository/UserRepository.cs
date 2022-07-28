using System.Collections.Generic;
using MarketPlace.Models;
using MySql.Data.MySqlClient;
using System;

namespace MarketPlace.Repository
{

    public class UserRepository : IUserRepository
    {
        private MySqlConnection _connection;
        public UserRepository()
        {
            string connectionString = "server=localhost;userid=root;password=kyleruban;database=mydb";
            _connection = new MySqlConnection(connectionString);
            _connection.Open();

        }

        ~UserRepository()
        {
            _connection.Close();
        }

        public void InsertUser(User u)
        {
            var statement = "Insert into User (UserID, UserName, FirstName, LastName, Password, Email) Values (@id,@uname,@fname,@lname,@pwd,@email)";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@id", u.UserID);
            command.Parameters.AddWithValue("@uname", u.UserName);
            command.Parameters.AddWithValue("@fname", u.FirstName);
            command.Parameters.AddWithValue("@lname", u.LastName);
            command.Parameters.AddWithValue("@pwd", u.Password);
            command.Parameters.AddWithValue("@email", u.Email);

            int result = command.ExecuteNonQuery();

            Console.WriteLine(result);

        }


    }


}