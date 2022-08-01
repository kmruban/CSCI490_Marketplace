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
        public User Login(User u)
        {
            var statement = "SELECT * FROM User WHERE UserName=@uname && Password=@pwd";
            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@uname", u.UserName);
            command.Parameters.AddWithValue("@pwd", u.Password);
            var results = command.ExecuteReader();
            User m = null;
            if (results.Read())
            {
                m = new User
                {
                    UserID = (int)results[0],
                    UserName = (string)results[1],
                    FirstName = (string)results[2],
                    LastName = (string)results[3],
                    Password = (string)results[4],
                    Email = (string)results[5]
                };
            }
            results.Close();
            return m;
        }

        public void RegisterUser(User u)
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
        }

        public IEnumerable<User> GetAllUsers()
        {
            var statement = "Select * from User";
            var command = new MySqlCommand(statement, _connection);
            var results = command.ExecuteReader();
            List<User> newList = new List<User>();
            while (results.Read())
            {
                User m = new User
                {
                    UserID = (int)results[0],
                    UserName = (string)results[1],
                    FirstName = (string)results[2],
                    LastName = (string)results[3],
                    Password = (string)results[4],
                    Email = (string)results[5]
                };
                newList.Add(m);

            }
            results.Close();
            return newList;
        }

        public void UpdateUser(int UserID, User userIn)
        {
            var statement = "Update User Set UserName=@newUserName, FirstName=@newFirstName, LastName=@newLastName, Password=@newPassword, Email=@newEmail Where UserID=@updateID";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@newUserName", userIn.UserName);
            command.Parameters.AddWithValue("@newFirstName", userIn.FirstName);
            command.Parameters.AddWithValue("@newLastName", userIn.LastName);
            command.Parameters.AddWithValue("@newPassword", userIn.Password);
            command.Parameters.AddWithValue("@newEmail", userIn.Email);
            command.Parameters.AddWithValue("@updateID", UserID);

            int result = command.ExecuteNonQuery();
        }

        public void DeleteUser(int UserID)
        {
            var statement = "DELETE FROM User Where UserID=@deleteID";

            var command = new MySqlCommand(statement, _connection);
            command.Parameters.AddWithValue("@deleteID", UserID);

            int result = command.ExecuteNonQuery();

        }


    }

}