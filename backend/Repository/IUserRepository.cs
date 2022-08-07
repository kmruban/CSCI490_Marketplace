using System.Collections.Generic;
using MarketPlace.Models;
using System.Threading.Tasks;

namespace MarketPlace.Repository
{
    public interface IUserRepository
    {
        public Task<User> Login(User u);
        public void RegisterUser(User u);
        public Task<IList<User>> GetAllUsers();
        public Task<User> GetUserByID(int ItemID);
        public void UpdateUser(int UserID, User u);
        public void DeleteUser(int UserID);

    }
    
}