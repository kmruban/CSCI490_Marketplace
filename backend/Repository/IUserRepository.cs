using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository
{
    public interface IUserRepository
    {
        public User Login(User u);
        public void RegisterUser(User u);
        public IEnumerable<User> GetAllUsers();
        public void UpdateUser(int UserID, User u);
        public void DeleteUser(int UserID);

    }
    
}