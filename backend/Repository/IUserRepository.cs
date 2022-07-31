using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public void InsertUser(User u);
        public void UpdateUser(int UserId, User u);
        public void DeleteUser(int id);

    }
    
}