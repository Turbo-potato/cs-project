using DiasApp.Interfaces;
using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }

        public async Task Save(User user)
        {
            await _userRepo.Save();
        }

        public async Task Insert(User user)
        {
            _userRepo.InsertUser(user);
            await _userRepo.Save();
        }

        public async Task Update(User user)
        {
            _userRepo.UpdateUser(user);
            await _userRepo.Save();
        }

        public User GetUserByID(int id)
        {
            return _userRepo.GetUserByID(id);
        }

        public async Task Delete(User user)
        {
            _userRepo.DeleteUser(user);
            await _userRepo.Save();
        }

        public bool UserExists(int id)
        {
            return _userRepo.UserExists(id);
        }

        public async Task<User> SearchByEmail(string text)
        {
            text = text.ToLower();
            User searchedUser = await _userRepo.GetUserWithPredicate(user => user.Email.ToLower() == text);
            return searchedUser;
        }
    }
}
