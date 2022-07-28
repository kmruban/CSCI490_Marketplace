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

        public void CreateUser(User u)
        {
            _repo.InsertUser(u);
        }

    }

}