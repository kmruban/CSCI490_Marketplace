using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;
using System.Threading.Tasks;

namespace MarketPlace.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public Task<User> Login(User u)
        {
            return _repo.Login(u);
        }
        public void RegisterUser(User u)
        {
            _repo.RegisterUser(u);
        }
        public Task<IList<User>> GetAllUsers()
        {
            Task<IList<User>> myList = _repo.GetAllUsers();

            return myList;
        }
        public Task<User> GetUserByID(int UserID)
        {
            Task<User> user = _repo.GetUserByID(UserID);
            return user;
        }
        public void UpdateUser(int UserID, User u)
        {
            _repo.UpdateUser(UserID, u);
        }
        public void DeleteUser(int UserID)
        {
            _repo.DeleteUser(UserID);
        }

    }

}