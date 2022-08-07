using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;
using System.Threading.Tasks;

namespace MarketPlace.Services
{
    public interface IUserServices
    {
        public Task<User> Login(User u);
        public void RegisterUser(User u);
        public Task<IList<User>> GetAllUsers();
        public Task<User> GetUserByID(int UserID);
        public void UpdateUser(int UserID, User u);
        public void DeleteUser(int UserID);

    }

}