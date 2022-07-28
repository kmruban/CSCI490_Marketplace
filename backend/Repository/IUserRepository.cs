using System.Collections.Generic;
using MarketPlace.Models;

namespace MarketPlace.Repository
{
    public interface IUserRepository
    {
        public void InsertUser(User u);
        
    }
    
}