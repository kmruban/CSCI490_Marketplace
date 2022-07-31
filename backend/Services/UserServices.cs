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

        public IEnumerable<User> GetUsers()
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
        public void CreateUser(User u)
        {
            _repo.InsertUser(u);
        }
        public void UpdateUser(int UserId, User u)
        {
            _repo.UpdateUser(UserId, u);
        }
        public void DeleteUser(int id)
        {
            _repo.DeleteUser(id);
        }

    }

}