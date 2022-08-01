using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services
{
    public interface IUserServices
    {
        public User Login(User u);
        public void RegisterUser(User u);
        public IEnumerable<User> GetAllUsers();
        public User GetUserByID(int UserID);
        public void UpdateUser(int UserID, User u);
        public void DeleteUser(int UserID);

    }

}