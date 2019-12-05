using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<List<User>> GetUsers();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(int id);
        Task Save();
        Task<User> GetUserWithPredicate(Expression<Func<User, bool>> predicate);
        Task<List<User>> GetUsersWithPredicate(Expression<Func<User, bool>> predicate);
    }
}
