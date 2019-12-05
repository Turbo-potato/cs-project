using DiasApp.Data;
using DiasApp.Interfaces;
using DiasApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DiasApp.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private PharmacyContext context;

        public UserRepository(PharmacyContext context)
        {
            this.context = context;
        }

        public Task<List<User>> GetUsers()
        {
            return context.User.ToListAsync();
        }

        public User GetUserByID(int id)
        {
            return context.User.Find(id);
        }

        public void InsertUser(User user)
        {
            context.User.Add(user);
        }

        public void DeleteUser(User user)
        {
            //User user = context.User.Find(userID);
            context.User.Remove(user);
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        //temp FIX
        public bool UserExists(int id)
        {
            return context.User.Any(e => e.Id == id.ToString());
        }

        public Task<List<User>> GetUsersWithPredicate(Expression<Func<User, bool>> predicate)
        {
            return context.User.Where(predicate).ToListAsync();
        }

        public Task<User> GetUserWithPredicate(Expression<Func<User, bool>> predicate)
        {
            return context.User.Where(predicate).FirstAsync();
        }


        //DISPOSING

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
