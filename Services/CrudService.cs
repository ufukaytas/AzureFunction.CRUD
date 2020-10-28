 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Function.Data;
using CRUD.Function.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Function.Services
{
    public class CrudService : ICRUDService
    {
        private readonly DataContext _ctx;

            public CrudService(DataContext context)
            {
                _ctx = context;
            }

       #region "CRUD"

        public async Task<User> CreateAsync(User user)
        {
            if(await UserExists(user.Name))
                return null;
            _ctx.Users.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await ReadAsync(id);
            if(user == null)
            {
                return false;
            }
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> ListAsync()
        {
            var userList = await _ctx.Users.ToListAsync();
            return userList;
        }

        public async Task<User> ReadAsync(Guid id)
        {
            var user = await _ctx.Users.FindAsync(id);
            return user;
        }

        public async Task<User> UpdateAsync(Guid id, User user)
        {
            var userToBeUpdated = await ReadAsync(id);
            if(userToBeUpdated == null || user == null)
            {
                return null;
            }
            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Password = user.Password;
            await _ctx.SaveChangesAsync();
            return userToBeUpdated;
        }

        public async Task<bool> UserExists(string username)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Name == username) != null;
        }

       #endregion
    }

}
