using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRUD.Function.Model;

namespace CRUD.Function.Services
{
    public interface ICRUDService
    {
        Task<User> CreateAsync(User user);
        Task<User> ReadAsync(Guid id);
        Task<User> UpdateAsync(Guid id, User user);
        Task<bool> DeleteAsync(Guid id);
        Task<List<User>> ListAsync();
    }
}