using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services
{
    public interface IUserServices
    {
        public IEnumerable<User> GetUsers();
        public User GetUserByID(int UserID);
        public void CreateUser(User u);
        public void UpdateUser(int UserId, User u);
        public void DeleteUser(int id);

    }

}