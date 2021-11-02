using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEstoque.Models;

namespace WebApiEstoque.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Estoquista", Password = "inDEVs01", Role = "manager" });
            users.Add(new User { Id = 1, Username = "Lojista", Password = "inDEVs02", Role = "employee" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
