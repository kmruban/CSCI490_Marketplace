using System.Collections.Generic;
using MarketPlace.Models;
using System.Collections;
using MarketPlace.Repository;

namespace MarketPlace.Services
{
    public class UserService : IUserServices
    {
        private IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public User Login(User u)
        {
            return _repo.Login(u);
        }
        public void RegisterUser(User u)
        {
            _repo.RegisterUser(u);
        }
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> myList = _repo.GetAllUsers();

            return myList;
        }
        public User GetUserByID(int UserID)
        {
            IEnumerable<User> mylist = _repo.GetAllUsers();
            foreach (User m in mylist)
            {
                if (m.UserID == UserID)
                    return m;
            }
            return null;
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